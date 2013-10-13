#region Using Statements

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

#endregion

namespace HoneyCube.Components
{
    /// <summary>
    /// The TransformComponent allows to position an entity in 3d space. Furthermore
    /// it provides a lot of different methods and interfaces to maniuplate its
    /// position, orientation or size. It is possible to create a hierarchy of 
    /// TransformComponents.
    /// </summary>
    /// <remarks>
    /// The interface of the TransformComponent equals the interface of the Transform
    /// behavior of Unity3D as it has proved to be easy to use. The implementation of
    /// these methods though are fully self-implemented.
    /// </remarks>
    public class TransformComponent : EntityComponent
    {
        #region Enum

        /// <summary>
        /// Allows to mark certain members as dirty to perform recalculations 
        /// only if necessary.
        /// </summary>
        [Flags]
        private enum DirtyFlags : byte
        {
            /// <summary>
            /// Indicates that all properties are up to date
            /// </summary>
            None = 0,

            /// <summary>
            /// Indicates that the local axes needs to be updated.
            /// </summary>
            LocalAxis = 1,

            /// <summary>
            /// Indicates that the transformation matrix needs to be updated.
            /// </summary>
            Transform = 2,

            /// <summary>
            /// Indicates that all properties need to updated.
            /// </summary>
            All = LocalAxis | Transform
        }

        /// <summary>
        /// Allows to identify which properties have changed during the current
        /// frame.
        /// </summary>
        private enum PropertyChangedFlag : byte
        {
            /// <summary>
            /// None of the properties have changed.
            /// </summary>
            None = 0,

            /// <summary>
            /// The scale value has been changed.
            /// </summary>
            Scale = 1,

            /// <summary>
            /// The orientation value has been changed.
            /// </summary>
            Orientation = 2,

            /// <summary>
            /// The translation value value has been changed.
            /// </summary>
            Translation = 4,

            /// <summary>
            /// All properties have been changed.
            /// </summary>
            All = Scale | Orientation | Translation
        }

        #endregion

        #region Fields

        private DirtyFlags _dirtyFlag;
        private PropertyChangedFlag _propertyChangedFlag;
        private bool _isStatic;

        private Vector3 _scale;
        private Vector3 _translation;
        private Vector3 _forward;
        private Vector3 _up;
        private Vector3 _right;
        private Quaternion _rotation;
        private Matrix _transform;

        private TransformComponent _parent;
        private List<TransformComponent> _children;

        #endregion

        #region Events

        /// <summary>
        /// Is raised every time some properties of the component have changed.
        /// </summary>
        public event EventHandler<EventArgs> Changed;

        /// <summary>
        /// Is raised every time the position of the entity is changed (will 
        /// be only raised once per update cycle).
        /// </summary>
        public event EventHandler<EventArgs> PositionChanged;

        /// <summary>
        /// Is raised every time the orientation of the entity is changed (will 
        /// be only raised once per update cycle).
        /// </summary>
        public event EventHandler<EventArgs> OrientationChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Determines whether the current entity can be moved. Will be used
        /// by a scene graph to optimize rendering performance.
        /// </summary>
        public bool IsStatic
        {
            get { return _isStatic; }
            set { _isStatic = value; }
        }

        /// <summary>
        /// The scale value can be used to modify the overal size of an entity.
        /// The default scale value is set to (1, 1, 1). Using values that are
        /// smaller than one will cause the entity to shrink in the specified axis.
        /// Using a value larger than one will cause the entity to grow.
        /// </summary>
        public Vector3 Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                _dirtyFlag |= DirtyFlags.Transform;
                _propertyChangedFlag |= PropertyChangedFlag.Scale;
            }
        }

        /// <summary>
        /// Allows to specify the position of the entity in local space. 
        /// </summary>
        public Vector3 Translation
        {
            get { return _translation; }
            set
            {
                _translation = value;
                _dirtyFlag |= DirtyFlags.Transform;
                _propertyChangedFlag |= PropertyChangedFlag.Translation;
            }
        }

        /// <summary>
        /// Returns the direction the entity is heading to.
        /// </summary>
        public Vector3 Forward
        {
            get
            {
                if ((_dirtyFlag & DirtyFlags.LocalAxis) != 0)
                    UpdateLocalAxis();

                return _forward;
            }
        }

        /// <summary>
        /// Returns the up direction of the current entity.
        /// </summary>
        public Vector3 Up
        {
            get
            {
                if ((_dirtyFlag & DirtyFlags.LocalAxis) != 0)
                    UpdateLocalAxis();

                return _up;
            }
        }

        /// <summary>
        /// Returns a direction vector which is orthogonal to the forward
        /// and up vector.
        /// </summary>
        public Vector3 Right
        {
            get
            {
                if ((_dirtyFlag & DirtyFlags.LocalAxis) != 0)
                    UpdateLocalAxis();

                return _right;
            }
        }

        /// <summary>
        /// Allows to rotate the entity using quaternions.
        /// </summary>
        public Quaternion Orientation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
                _dirtyFlag |= (DirtyFlags.LocalAxis | DirtyFlags.Transform);
                _propertyChangedFlag |= PropertyChangedFlag.Orientation;
            }
        }

        /// <summary>
        /// The world transformation matrix of the entity including the scale, 
        /// orientation and translation values.
        /// </summary>
        public Matrix WorldTransform
        {
            get
            {
                if ((_dirtyFlag & DirtyFlags.Transform) != 0)
                    UpdateTransform();

                return _transform;
            }
        }

        /// <summary>
        /// The parent transformation node of the current component.
        /// </summary>
        public TransformComponent Parent
        {
            get { return _parent; }
            internal set { _parent = value; }
        }

        /// <summary>
        /// The total number of children attached to the current transform component.
        /// </summary>
        public int ChildCount
        {
            get { return _children.Count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new transform component.
        /// </summary>
        public TransformComponent()
            : base()
        {
            _children = new List<TransformComponent>();
            _scale = Vector3.One;
            _rotation = Quaternion.Identity;
            _translation = Vector3.Zero;
            _dirtyFlag = DirtyFlags.All;
        }

        /// <summary>
        /// Public constructor. Creates a new transform component.
        /// </summary>
        /// <param name="name">The name of the component.</param>
        public TransformComponent(string name)
            : base(name)
        {
            _children = new List<TransformComponent>();
            _scale = Vector3.One;
            _rotation = Quaternion.Identity;
            _translation = Vector3.Zero;
            _dirtyFlag = DirtyFlags.All;
        }

        #endregion

        #region Hierachy Management

        /// <summary>
        /// Adds a transformation component to the current node to allow 
        /// hierarchical transformation.
        /// </summary>
        /// <param name="transform">The transformation component to attach.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="transform"/> component is null.
        /// </exception>
        public void AddChild(TransformComponent transform)
        {
            if (transform == null)
                throw new ArgumentNullException("The specified transformation component is null.");

            // Detach from the old parent
            if (transform._parent != null && transform._parent != this)
                transform._parent.RemoveChild(transform);

            // Attach the component to the current node, if not already done.
            if (transform._parent == null)
            {
                // Assign the parent reference
                transform._parent = this;

                // Add the component to the current collection
                _children.Add(transform);
            }
        }

        /// <summary>
        /// Tries to remove the specified component from the current node.
        /// </summary>
        /// <param name="transform">The transformation component to remove.</param>
        /// <returns>True if the component was removed successfully.</returns>
        public bool RemoveChild(TransformComponent transform)
        {
            if (_children.Remove(transform))
            {
                // Remove the reference to the current node
                transform._parent = null;

                // Notify the caller that the component has been removed
                return true;
            }

            // Component could not be found
            return false;
        }

        /// <summary>
        /// Removes all children from the current node.
        /// </summary>
        public void RemoveAllChildren()
        {
            for (int i = 0, n = _children.Count; i != n; ++i)
                _children[i].Parent = null;

            _children.Clear();
        }

        /// <summary>
        /// Tries to retrieve the transformation component within the collection
        /// of child nodes by the specified name. Performs a sequential search on
        /// all child elements [O(1,...,n)]. Returns only the first appearance of
        /// the name.
        /// </summary>
        /// <param name="name">The name of the transformation component.</param>
        /// <returns>A reference to the transformation component.</returns>
        public TransformComponent GetByName(string name)
        {
            for (int i = 0, n = _children.Count; i != n; ++i)
                if (_children[i].Name.Equals(name))
                    return _children[i];

            return null;
        }

        /// <summary>
        /// Tries to find a transformation component with a certain tag within
        /// the collection of child nodes. Performs a sequential search on
        /// all child elements [O(1,...,n)]. Returns only the first appearance 
        /// of the tag.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>A reference to the transformation component.</returns>
        public TransformComponent FindWithTag(string tag)
        {
            for (int i = 0, n = _children.Count; i != n; ++i)
                if (_children[i].Tag.Equals(tag))
                    return _children[i];

            return null;
        }

        /// <summary>
        /// Tries to find all transformation components that are added as a child
        /// to the current node and share the same tag value. Performs a sequential 
        /// search on all child elements [O(1,...,n)].
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="collection">The collection that should hold the resulting components.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="collection"/> is null.
        /// </exception>
        public void FindAllWithTag(string tag, ICollection<TransformComponent> collection)
        {
            if (_children == null)
                throw new ArgumentNullException("The specified collection is null");

            for (int i = 0, n = _children.Count; i != n; ++i)
                if (_children[i].Tag.Equals(tag))
                    collection.Add(_children[i]);
        }

        /// <summary>
        /// Checks whether the current transformation component is a child of
        /// the specified component.
        /// </summary>
        /// <param name="transform">The transformation component that might be the parent.</param>
        /// <returns>True if the current component is a child of the specified one.</returns>
        public bool IsChildOf(TransformComponent transform)
        {
            return _parent == transform;
        }

        /// <summary>
        /// Checks whether the current transformation component is the parent
        /// of the specified component.
        /// </summary>
        /// <param name="transform">The transformation component that might be the child node.</param>
        /// <returns>True if the current component is the parent of the specified one.</returns>
        public bool IsParentOf(TransformComponent transform)
        {
            return _children.Contains(transform);
        }

        #endregion

        #region Transformation

        /// <summary>
        /// Moves the entity the specified amount into the specified 
        /// direction in local space.
        /// </summary>
        /// <param name="translation">The amount and direction to move to.</param>
        public void Move(Vector3 translation)
        {
            Move(translation, 1f, TransformationSpace.Local);
        }

        /// <summary>
        /// Moves the entity the specified amount into the specified
        /// direction.
        /// </summary>
        /// <param name="translation">The amount and direction to move to.</param>
        /// <param name="space">The coordinate system that should be used to move the entity: local or world space.</param>
        public void Move(Vector3 translation, TransformationSpace space)
        {
            Move(translation, 1f, space);
        }

        /// <summary>
        /// Moves the entity the specified amount into the specified 
        /// direction in local space.
        /// </summary>
        /// <param name="direction">The direction to move.</param>
        /// <param name="amount">The amount to move the entity into that direction.</param>
        public void Move(Vector3 direction, float amount)
        {
            Move(direction, amount, TransformationSpace.Local);
        }

        /// <summary>
        /// Moves the entity the specified amount into the specified
        /// direction.
        /// </summary>
        /// <param name="direction">The direction to move.</param>
        /// <param name="amount">The amount to move the entity into that direction.</param>
        /// <param name="space">The coordinate system that should be used to move the entity: local or world space.</param>
        public void Move(Vector3 direction, float amount, TransformationSpace space)
        {
            if (space == TransformationSpace.Local)
            {
                Vector3.Transform(ref direction, ref _rotation, out direction);
                direction.Normalize();
            }

            _translation += direction * amount;
            _dirtyFlag |= DirtyFlags.Transform;
            _propertyChangedFlag |= PropertyChangedFlag.Translation;
        }

        /// <summary>
        /// Rotates the entity in local space using euler angles in radians.
        /// </summary>
        /// <param name="eulerAngles">The angles to rotate the entity in radians.</param>
        public void Rotate(Vector3 eulerAngles)
        {
            Rotate(eulerAngles.X, eulerAngles.Y, eulerAngles.Z, TransformationSpace.Local);
        }

        /// <summary>
        /// Rotates the entity using euler angles in radians.
        /// </summary>
        /// <param name="eulerAngles">The angles to rotate the entity in radians.</param>
        /// <param name="space">The coordinate system that should be used to rotate the entity: local or world space.</param>
        public void Rotate(Vector3 eulerAngles, TransformationSpace space)
        {
            Rotate(eulerAngles.X, eulerAngles.Y, eulerAngles.Z, space);
        }

        /// <summary>
        /// Rotates the entity in local space using roll, yaw and pitch values.
        /// </summary>
        /// <param name="x">The angle used to roll the entity in radians (rotate around x-Axis).</param>
        /// <param name="y">The angle used to yaw the entity in radians (rotate around y-Axis).</param>
        /// <param name="z">The angle used to pitch the entity in radians (rotate around z-Axis).</param>
        public void Rotate(float x, float y, float z)
        {
            Rotate(x, y, z, TransformationSpace.Local);
        }

        /// <summary>
        /// Rotates the entity using roll, yaw and pitch values.
        /// </summary>
        /// <param name="x">The angle used to roll the entity in radians (rotate around x-Axis).</param>
        /// <param name="y">The angle used to yaw the entity in radians (rotate around y-Axis).</param>
        /// <param name="z">The angle used to pitch the entity in radians (rotate around z-Axis).</param>
        /// <param name="space">The coordinate system that should be used to rotate the entity: local or world space.</param>
        public void Rotate(float x, float y, float z, TransformationSpace space)
        {
            // Perform rotation
            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(y, x, z);

            switch (space)
            {
                case TransformationSpace.Local:
                    Quaternion.Multiply(ref _rotation, ref rotate, out _rotation);
                    break;
                case TransformationSpace.World:
                    Quaternion.Multiply(ref rotate, ref _rotation, out _rotation);
                    break;
            }

            // Accumulate for numerical errors
            _rotation.Normalize();

            // Force an update of dependent properties
            _dirtyFlag |= (DirtyFlags.LocalAxis | DirtyFlags.Transform);
            _propertyChangedFlag |= PropertyChangedFlag.Orientation;
        }

        /// <summary>
        /// Rotates the entity around a certain axis.
        /// </summary>
        /// <param name="axis">The axis to rotate around.</param>
        /// <param name="radians">The angle in radians.</param>
        public void RotateAround(Vector3 axis, float radians)
        {
            // Perform rotation
            Quaternion rotate;
            Quaternion.CreateFromAxisAngle(ref axis, radians, out rotate);
            Quaternion.Multiply(ref _rotation, ref rotate, out _rotation);

            // Accumulate for numerical errors
            _rotation.Normalize();

            // Force an update of dependent properties
            _dirtyFlag |= (DirtyFlags.LocalAxis | DirtyFlags.Transform);
            _propertyChangedFlag |= PropertyChangedFlag.Orientation;
        }

        /// <summary>
        /// Forces the entity to look at the specified target position.
        /// </summary>
        /// <param name="target">The position to look at.</param>
        public void LookAt(Vector3 target)
        {
            LookAt(target, Up);
        }

        /// <summary>
        /// Forces the entity to look at the specified target position.
        /// </summary>
        /// <param name="target">The position to look at.</param>
        /// <param name="up">A vector which specifies the up direction of the entity.</param>
        public void LookAt(Vector3 target, Vector3 up)
        {
            // Calculate the new facing vector
            Vector3 forward = Vector3.Normalize(target - _translation);

            // Calculate the rotation axis
            Vector3 rotationAxis = Vector3.Normalize(Vector3.Cross(Forward, forward));

            // Calculate the dot product which will be used to calculate the
            // rotation angle
            float dotProduct = Vector3.Dot(Forward, forward);

            // Ensure that the two forward vectors do not point in opposite
            // directions
            if (Math.Abs(dotProduct + 1f) < float.Epsilon)
                _rotation = new Quaternion(up, MathHelper.Pi);

            // Ensure that both forward vectors do not point in the same
            // direction
            else if (Math.Abs(dotProduct - 1f) < float.Epsilon)
                _rotation = Quaternion.Identity;

            // Calculate the absolute rotation to look at the target point
            else
                Quaternion.CreateFromAxisAngle(ref rotationAxis, (float)Math.Acos(dotProduct), out _rotation);

            // Force an update of dependent properties
            _dirtyFlag |= (DirtyFlags.LocalAxis | DirtyFlags.Transform);
            _propertyChangedFlag |= PropertyChangedFlag.Orientation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public Quaternion LookAt2(Vector3 target)
        {
            // the new forward vector, so the avatar faces the target
            Vector3 newForward = target - _translation;
            // calc the rotation so the avatar faces the target
            return GetRotation(Forward, newForward, Up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="up"></param>
        /// <returns></returns>
        public static Quaternion GetRotation(Vector3 source, Vector3 dest, Vector3 up)
        {
            float dot = Vector3.Dot(source, dest);

            if (Math.Abs(dot - (-1.0f)) < 0.000001f)
            {
                // vector a and b point exactly in the opposite direction, 
                // so it is a 180 degrees turn around the up-axis
                return new Quaternion(up, MathHelper.ToRadians(180.0f));
            }
            if (Math.Abs(dot - (1.0f)) < 0.000001f)
            {
                // vector a and b point exactly in the same direction
                // so we return the identity quaternion
                return Quaternion.Identity;
            }

            float rotAngle = (float)Math.Acos(dot);
            Vector3 rotAxis = Vector3.Cross(source, dest);
            rotAxis = Vector3.Normalize(rotAxis);
            return Quaternion.CreateFromAxisAngle(rotAxis, rotAngle);
        }
        
        /// <summary>
        /// Takes a position point in local space of the entity and transforms
        /// it back to world space.
        /// </summary>
        /// <param name="point">The point to transform from local to world space.</param>
        /// <returns>The transformed position vector.</returns>
        public Vector3 TransformLocalToWorld(Vector3 point)
        {
            Vector3.Transform(ref point, ref _transform, out point);
            return point;
        }

        /// <summary>
        /// Takes a position point in local space of the entity and transforms
        /// it back to world space.
        /// </summary>
        /// <param name="localPoint">The local position to transform to world space.</param>
        /// <param name="worldPoint">(OUT) The vector holding the resulting world position.</param>
        public void TransformLocalToWorld(ref Vector3 localPoint, out Vector3 worldPoint)
        {
            Vector3.Transform(ref localPoint, ref _transform, out worldPoint);
        }

        /// <summary>
        /// Takes a position in world space and transforms it back into the
        /// local coordinate system of the current entity.
        /// </summary>
        /// <param name="point">The local position to transform from world space to local space.</param>
        public Vector3 TransformWorldToLocal(Vector3 point)
        {
            Matrix inverse = Matrix.Invert(_transform);
            Vector3.Transform(ref point, ref inverse, out point);
            return point;
        }

        /// <summary>
        /// Takes a position in world space and transforms it back into the
        /// local coordinate system of the current entity.
        /// </summary>
        /// <param name="worldPoint">The world position to transform to local space.</param>
        /// <param name="localPoint">(OUT) The vector holding the resulting local position.</param>
        public void TransformWorldToLocal(ref Vector3 worldPoint, out Vector3 localPoint)
        {
            Matrix inverse = Matrix.Invert(_transform);
            Vector3.Transform(ref worldPoint, ref inverse, out localPoint);
        }

        /// <summary>
        /// Resets the current component to its original state.
        /// </summary>
        public void Reset()
        {
            _scale = Vector3.One;
            _rotation = Quaternion.Identity;
            _translation = Vector3.Zero;
            _dirtyFlag = DirtyFlags.All;
            _propertyChangedFlag = PropertyChangedFlag.All;
        }

        #endregion

        #region Update

        /// <summary>
        /// Allows to update the transformation of the entity. Accounts for the
        /// hierachy and uses flags to only update properties which really 
        /// need a refresh.
        /// </summary>
        /// <param name="gameTime">A snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // Iterate all available child nodes
            for (int i = 0, n = _children.Count; i != n; ++i)
            {
                // Cache the currently iterated child node
                TransformComponent child = _children[i];

                // Enforce an transformation update on the child node if any 
                // of the properties have been modified
                if (_propertyChangedFlag != PropertyChangedFlag.None)
                    child._dirtyFlag |= DirtyFlags.Transform;

                // Allow the child component to do the same
                if (child.Enabled)
                    child.Update(gameTime);
            }

            // Notify subscribers that some properties changed
            if ((_propertyChangedFlag & PropertyChangedFlag.Scale) != 0
                || (_propertyChangedFlag & PropertyChangedFlag.Orientation) != 0
                || (_propertyChangedFlag & PropertyChangedFlag.Translation) != 0)
                OnChanged();

            // Notify subscribers that the position changed
            if ((_propertyChangedFlag & PropertyChangedFlag.Translation) != 0)
                OnPositionChanged();

            // Notify subscribers that the orientation changed
            if ((_propertyChangedFlag & PropertyChangedFlag.Orientation) != 0)
                OnRotationChanged();

            // Reset the property changed flag
            _propertyChangedFlag = PropertyChangedFlag.None;
        }

        /// <summary>
        /// Updates the world transformation matrix of the current entity.
        /// Accounts for the relation to the parent component.
        /// </summary>
        protected void UpdateTransform()
        {
            // Calculate the local transformation
            _transform = Matrix.CreateScale(_scale)
                        * Matrix.CreateFromQuaternion(_rotation)
                        * Matrix.CreateTranslation(_translation);

            // Include the parent transformation
            if (_parent != null)
                _transform = _transform * _parent.WorldTransform;

            // Clear the flag
            _dirtyFlag &= ~DirtyFlags.Transform;
        }

        /// <summary>
        /// Updates the local axis in case the entity has been rotated. Does
        /// use a custom implementation of a quaternion to matrix conversion
        /// to save some calculations. Could also have been done by using 
        /// Matrix.CreateFromQuaternion and then by calling the three axis
        /// available as properties of the matrix.
        /// </summary>
        /// <remarks>
        /// Based on the quaternion to matrix conversion available on 
        /// euclideanspace.com:
        /// http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToMatrix/index.htm
        /// </remarks>
        protected void UpdateLocalAxis()
        {
            float xx = _rotation.X * _rotation.X;
            float xy = _rotation.X * _rotation.Y;
            float xz = _rotation.X * _rotation.Z;
            float xw = _rotation.X * _rotation.W;
            float yy = _rotation.Y * _rotation.Y;
            float yz = _rotation.Y * _rotation.Z;
            float yw = _rotation.Y * _rotation.W;
            float zz = _rotation.Z * _rotation.Z;
            float zw = _rotation.Z * _rotation.W;

            // Calculate the right vector (X-Axis: M11, M12, M13)
            _right.X = 1f - 2f * (yy + zz);
            _right.Y = 2f * (xy + zw);
            _right.Z = 2f * (xz - yw);

            // Calculate the up vector (Y-Axis: M21, M22, M23)
            _up.X = 2f * (xy - zw);
            _up.Y = 1f - 2f * (xx + zz);
            _up.Z = 2f * (yz + xw);

            // Calculate the forward vector (-Z-Axis: -M31, -M32, -M33)
            _forward.X = -2f * (xz + yw);
            _forward.Y = -2f * (yz - xw);
            _forward.Z = -1f * (1f - 2f * (xx + yy));

            // Clear the flag
            _dirtyFlag &= ~DirtyFlags.LocalAxis;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Is called every time some properties of the transform component 
        /// is changed.
        /// </summary>
        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Is called when the components position has changed. Notifies 
        /// all subscribers of this event.
        /// </summary>
        protected virtual void OnPositionChanged()
        {
            if (PositionChanged != null)
                PositionChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Is called when the components rotation value has changed. Notifies 
        /// all subscribers of this event.
        /// </summary>
        protected virtual void OnRotationChanged()
        {
            if (OrientationChanged != null)
                OrientationChanged(this, EventArgs.Empty);
        }

        #endregion
    }

    #region TransformationSpace Enumeration

    /// <summary>
    /// Describes the space in which a transformation should be applied.
    /// </summary>
    public enum TransformationSpace
    {
        /// <summary>
        /// The transformation is applied in local space.
        /// </summary>
        Local,

        /// <summary>
        /// The transformation is applied in world space.
        /// </summary>
        World
    }

    #endregion
}

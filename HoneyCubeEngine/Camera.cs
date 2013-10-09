#region Using Statements

using Microsoft.Xna.Framework;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// The Camera class provides a rudimental implementation of the ICamera 
    /// interface and will only be used when no other camera is specified for
    /// the rendering system. If you are looking for a more powerful 
    /// implementation use the component system and the CameraComponent.
    /// </summary>
    public class Camera : ICamera
    {
        #region Fields

        private Matrix _world;
        private Matrix _view;
        private Matrix _projection;
        private BoundingFrustum _frustum;

        /// <summary>
        /// Describes a default camera positioned at the world origin (0,0,0)
        /// heading to negative z.
        /// </summary>
        public static ICamera Default = new Camera();

        #endregion

        #region Properties

        /// <summary>
        /// The world transformation matrix of the camera.
        /// </summary>
        public Matrix World
        {
            get { return _world; }
            set
            {
                _world = value;
                Matrix.Invert(ref _world, out _view);
                _frustum.Matrix = _view * _projection;
            }
        }

        /// <summary>
        /// The view transformation matrix allows to transform a position
        /// vector from the world coordinate system into the coordinate system
        /// of the camera. After the transformation the coordinates will be
        /// relative to the camera.
        /// </summary>
        public Matrix View
        {
            get { return _view; }
            set
            {
                _view = value;
                _frustum.Matrix = _view * _projection;
            }
        }

        /// <summary>
        /// The projection transformation matrix allows to introduce a 
        /// perspective on the scene. The x and y axis are used to create a 2d
        /// projection of the scene while the z axis is used to determine an 
        /// objects size.
        /// </summary>
        public Matrix Projection
        {
            get { return _projection; }
            set
            {
                _projection = value;
                _frustum.Matrix = _view * _projection;
            }
        }

        /// <summary>
        /// The frustum is a volume which represents the viewing field of the
        /// camera. It is especially useful to check whether an object is in 
        /// view of the camera.
        /// </summary>
        public BoundingFrustum Frustum
        {
            get { return _frustum; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor. Creates a new default camera.
        /// </summary>
        public Camera()
        {
            _world = Matrix.CreateTranslation(Vector3.Backward * 500f);
            _view = Matrix.Invert(_world);
            _projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16f / 9f, 0.1f, 1000f);
            _frustum = new BoundingFrustum(_view * _projection);
        }

        /// <summary>
        /// Public constructor. Creates a new camera.
        /// </summary>
        /// <param name="world">The world transformation matrix holding the cameras position and orientation.</param>
        /// <param name="projection">The projection transformation matrix specifing the perspective on the world.</param>
        public Camera(Matrix world, Matrix projection)
        {
            _world = world;
            _view = Matrix.Invert(world);
            _projection = projection;
            _frustum = new BoundingFrustum(_view * _projection);
        }

        #endregion

        #region Transformation

        /// <summary>
        /// Takes a position point in local space of the camera and transforms
        /// it back to world space.
        /// </summary>
        /// <param name="point">The point to transform from local to world space.</param>
        /// <returns>The transformed position vector.</returns>
        public Vector3 TransformLocalToWorld(Vector3 point)
        {
            Vector3.Transform(ref point, ref _world, out point);
            return point;
        }

        /// <summary>
        /// Takes a position point in local space of the camera and transforms
        /// it back to world space.
        /// </summary>
        /// <param name="localPoint">The local position to transform to world space.</param>
        /// <param name="worldPoint">(OUT) The vector holding the resulting world position.</param>
        public void TransformLocalToWorld(ref Vector3 localPoint, out Vector3 worldPoint)
        {
            Vector3.Transform(ref localPoint, ref _world, out worldPoint);
        }

        /// <summary>
        /// Takes a position in world space and transforms it back into the
        /// local coordinate system of the current camera.
        /// </summary>
        /// <param name="point">The local position to transform from world space to local space.</param>
        public Vector3 TransformWorldToLocal(Vector3 point)
        {
            Matrix inverse = Matrix.Invert(_world);
            Vector3.Transform(ref point, ref inverse, out point);
            return point;
        }

        /// <summary>
        /// Takes a position in world space and transforms it back into the
        /// local coordinate system of the current camera.
        /// </summary>
        /// <param name="worldPoint">The world position to transform to local space.</param>
        /// <param name="localPoint">(OUT) The vector holding the resulting local position.</param>
        public void TransformWorldToLocal(ref Vector3 worldPoint, out Vector3 localPoint)
        {
            Matrix inverse = Matrix.Invert(_world);
            Vector3.Transform(ref worldPoint, ref inverse, out localPoint);
        }

        /// <summary>
        /// Resets the current component to its original state.
        /// </summary>
        public void Reset()
        {
            _world = Matrix.CreateTranslation(Vector3.Backward * 500f);
            _view = Matrix.Invert(_world);
            _projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16f / 9f, 0.1f, 1000f);
            _frustum.Matrix = _view * _projection;
        }

        #endregion
    }
}

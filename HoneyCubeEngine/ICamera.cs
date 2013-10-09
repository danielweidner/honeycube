#region Using Statements

using Microsoft.Xna.Framework;

#endregion

namespace HoneyCube
{
    /// <summary>
    /// The ICamera interface provides properties which describe a view on the
    /// game world.
    /// </summary>
    public interface ICamera
    {
        /// <summary>
        /// The world transformation matrix of the camera.
        /// </summary>
        Matrix World
        {
            get;
        }

        /// <summary>
        /// The view transformation matrix allows to transform a position
        /// vector from the world coordinate system into the coordinate system
        /// of the camera. After the transformation the coordinates will be
        /// relative to the camera.
        /// </summary>
        Matrix View
        {
            get;
        }

        /// <summary>
        /// The projection transformation matrix allows to introduce a 
        /// perspective on the scene. The x and y axis are used to create a 2d
        /// projection of the scene while the z axis is used to determine an
        /// objects size.
        /// </summary>
        Matrix Projection
        {
            get;
        }

        /// <summary>
        /// The frustum is a volume which represents the viewing field of the 
        /// camera. It is especially useful to check whether an object is in 
        /// view of the camera.
        /// </summary>
        BoundingFrustum Frustum
        {
            get;
        }
    }
}
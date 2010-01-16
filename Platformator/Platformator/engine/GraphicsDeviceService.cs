using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

#pragma warning disable 67

namespace Platformator
{
 class GraphicsDeviceService : IGraphicsDeviceService
 {
  static GraphicsDeviceService singletonInstance;
  static int referenceCount;

  GraphicsDeviceService(IntPtr windowHandle, int width, int height)
  {
   parameters = new PresentationParameters();

   parameters.BackBufferWidth = Math.Max(width, 1);
   parameters.BackBufferHeight = Math.Max(height, 1);
   parameters.BackBufferFormat = SurfaceFormat.Color;

   parameters.EnableAutoDepthStencil = true;
   parameters.AutoDepthStencilFormat = DepthFormat.Depth24;

   graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter,
                                       DeviceType.Hardware,
                                       windowHandle,
                                       parameters);
  }


  public static GraphicsDeviceService AddRef(IntPtr windowHandle,int width, int height)
  {
   // Increment the "how many controls sharing the device" reference count.
   if (Interlocked.Increment(ref referenceCount) == 1)
   {
    // If this is the first control to start using the
    // device, we must create the singleton instance.
    singletonInstance = new GraphicsDeviceService(windowHandle,
                                                  width, height);
   }

   return singletonInstance;
  }
  public void Release(bool disposing)
  {
   // Decrement the "how many controls sharing the device" reference count.
   if (Interlocked.Decrement(ref referenceCount) == 0)
   {
    // If this is the last control to finish using the
    // device, we should dispose the singleton instance.
    if (disposing)
    {
     if (DeviceDisposing != null)
      DeviceDisposing(this, EventArgs.Empty);

     graphicsDevice.Dispose();
    }

    graphicsDevice = null;
   }
  }
  public void ResetDevice(int width, int height)
  {
   if (DeviceResetting != null)
    DeviceResetting(this, EventArgs.Empty);

   parameters.BackBufferWidth = Math.Max(parameters.BackBufferWidth, width);
   parameters.BackBufferHeight = Math.Max(parameters.BackBufferHeight, height);

   graphicsDevice.Reset(parameters);

   if (DeviceReset != null)
    DeviceReset(this, EventArgs.Empty);
  }


  public GraphicsDevice GraphicsDevice
  {
   get { return graphicsDevice; }
  }
  GraphicsDevice graphicsDevice;


  // Store the current device settings.
  PresentationParameters parameters;


  // IGraphicsDeviceService events.
  public event EventHandler DeviceCreated;
  public event EventHandler DeviceDisposing;
  public event EventHandler DeviceReset;
  public event EventHandler DeviceResetting;
 }
}

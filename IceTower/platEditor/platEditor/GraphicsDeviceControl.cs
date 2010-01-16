using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace platEditor
{
 using Color = System.Drawing.Color;
 using Rectangle = Microsoft.Xna.Framework.Rectangle;


 abstract public class GraphicsDeviceControl : Control
 {
  GraphicsDeviceService graphicsDeviceService;
  public GraphicsDevice GraphicsDevice
  {
   get { return graphicsDeviceService.GraphicsDevice; }
  }
  public ServiceContainer Services
  {
   get { return services; }
  }
  ServiceContainer services = new ServiceContainer();


  protected override void OnCreateControl()
  {
   if (!DesignMode)
   {
    graphicsDeviceService = GraphicsDeviceService.AddRef(Handle,
                                                         ClientSize.Width,
                                                         ClientSize.Height);

    // Register the service, so components like ContentManager can find it.
    services.AddService<IGraphicsDeviceService>(graphicsDeviceService);

    // Give derived classes a chance to initialize themselves.
    Initialize();
   }

   base.OnCreateControl();
  }
  protected override void Dispose(bool disposing)
  {
   if (graphicsDeviceService != null)
   {
    graphicsDeviceService.Release(disposing);
    graphicsDeviceService = null;
   }

   base.Dispose(disposing);
  }
  protected override void OnPaint(PaintEventArgs e)
  {
   string beginDrawError = BeginDraw();

   if (string.IsNullOrEmpty(beginDrawError))
   {
    // Draw the control using the GraphicsDevice.
    Draw();
    EndDraw();
   }
   else
   {
    // If BeginDraw failed, show an error message using System.Drawing.
    PaintUsingSystemDrawing(e.Graphics, beginDrawError);
   }
  }
  string BeginDraw()
  {
   // If we have no graphics device, we must be running in the designer.
   if (graphicsDeviceService == null)
   {
    return Text + "\n\n" + GetType();
   }

   // Make sure the graphics device is big enough, and is not lost.
   string deviceResetError = HandleDeviceReset();

   if (!string.IsNullOrEmpty(deviceResetError))
   {
    return deviceResetError;
   }

   // Many GraphicsDeviceControl instances can be sharing the same
   // GraphicsDevice. The device backbuffer will be resized to fit the
   // largest of these controls. But what if we are currently drawing
   // a smaller control? To avoid unwanted stretching, we set the
   // viewport to only use the top left portion of the full backbuffer.
   Viewport viewport = new Viewport();

   viewport.X = 0;
   viewport.Y = 0;

   viewport.Width = ClientSize.Width;
   viewport.Height = ClientSize.Height;

   viewport.MinDepth = 0;
   viewport.MaxDepth = 1;

   GraphicsDevice.Viewport = viewport;

   return null;
  }
  void EndDraw()
  {
   try
   {
    Rectangle sourceRectangle = new Rectangle(0, 0, ClientSize.Width,
                                                    ClientSize.Height);

    GraphicsDevice.Present(sourceRectangle, null, this.Handle);
   }
   catch
   {
   }
  }
  string HandleDeviceReset()
  {
   bool deviceNeedsReset = false;

   switch (GraphicsDevice.GraphicsDeviceStatus)
   {
    case GraphicsDeviceStatus.Lost:
     // If the graphics device is lost, we cannot use it at all.
     return "Graphics device lost";

    case GraphicsDeviceStatus.NotReset:
     // If device is in the not-reset state, we should try to reset it.
     deviceNeedsReset = true;
     break;

    default:
     // If the device state is ok, check whether it is big enough.
     PresentationParameters pp = GraphicsDevice.PresentationParameters;

     deviceNeedsReset = (ClientSize.Width > pp.BackBufferWidth) ||
                        (ClientSize.Height > pp.BackBufferHeight);
     break;
   }

   // Do we need to reset the device?
   if (deviceNeedsReset)
   {
    try
    {
     graphicsDeviceService.ResetDevice(ClientSize.Width,
                                       ClientSize.Height);
    }
    catch (Exception e)
    {
     return "Graphics device reset failed\n\n" + e;
    }
   }

   return null;
  }
  protected virtual void PaintUsingSystemDrawing(Graphics graphics, string text)
  {
   graphics.Clear(Color.CornflowerBlue);

   using (Brush brush = new SolidBrush(Color.Black))
   {
    using (StringFormat format = new StringFormat())
    {
     format.Alignment = StringAlignment.Center;
     format.LineAlignment = StringAlignment.Center;

     graphics.DrawString(text, Font, brush, ClientRectangle, format);
    }
   }
  }
  protected override void OnPaintBackground(PaintEventArgs pevent)
  {
  }
  protected abstract void Initialize();
  protected abstract void Draw();
 }
}

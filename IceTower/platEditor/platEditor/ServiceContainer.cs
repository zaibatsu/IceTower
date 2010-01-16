using System;
using System.Collections.Generic;

namespace platEditor
{
 public class ServiceContainer : IServiceProvider
 {
  Dictionary<Type, object> services = new Dictionary<Type, object>();

  public void AddService<T>(T service)
  {
   services.Add(typeof(T), service);
  }

  public object GetService(Type serviceType)
  {
   object service;

   services.TryGetValue(serviceType, out service);

   return service;
  }
 }
}

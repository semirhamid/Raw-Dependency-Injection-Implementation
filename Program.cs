namespace HelloWorld
{
  // Interface for PrinterStarter
  public interface IPrinterStarter
  {
    void StartPrinter();
  }

  // PrinterStarter class implementing IPrinterStarter
  public class PrinterStarter : IPrinterStarter
  {
    public void StartPrinter()
    {
      Console.WriteLine("Printer Started");
    }
  }

  // Interface for HelloWorld
  public interface IHelloWorld
  {
    void PrintMessage();
  }

  // HelloWorld class implementing IHelloWorld
  public class HelloWorld : IHelloWorld
  {
    public void PrintMessage()
    {
      Console.WriteLine("Hello World");
    }
  }

  // Interface for MyName
  public interface IMyName
  {
    void PrintName();
  }

  // MyName class implementing IMyName
  public class MyName : IMyName
  {
    private readonly IPrinterStarter _printerStarter;

    public MyName(IPrinterStarter printerStarter)
    {
      _printerStarter = printerStarter;
    }

    public void PrintName()
    {
      _printerStarter.StartPrinter();
      Console.WriteLine("My Name is John Doe");
    }
  }

  // Custom lifetime management for dependency injection
  public enum Lifetime
  {
    Singleton,
    Transient
  }

  public class ServiceDescriptor
  {
    public Type ServiceType { get; }
    public Type ImplementationType { get; }
    public Lifetime Lifetime { get; }
    public object Implementation { get; set; }

    public ServiceDescriptor(Type serviceType, Type implementationType, Lifetime lifetime)
    {
      ServiceType = serviceType;
      ImplementationType = implementationType;
      Lifetime = lifetime;
    }
  }

  public class DependencyInjection
  {
    private readonly List<ServiceDescriptor> _services = new List<ServiceDescriptor>();

    public void AddDependency<TService, TImplementation>(Lifetime lifetime = Lifetime.Transient)
    {
      _services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime));
    }

    public object GetService(Type serviceType)
    {
      var serviceDescriptor = _services.SingleOrDefault(s => s.ServiceType == serviceType);

      if (serviceDescriptor == null)
        throw new Exception($"Service of type {serviceType} not registered");

      if (serviceDescriptor.Lifetime == Lifetime.Singleton && serviceDescriptor.Implementation != null)
        return serviceDescriptor.Implementation;

      var constructor = serviceDescriptor.ImplementationType.GetConstructors().First();
      var parameters = constructor.GetParameters();
      var parameterInstances = parameters.Select(parameter => GetService(parameter.ParameterType)).ToArray();

      var implementation = Activator.CreateInstance(serviceDescriptor.ImplementationType, parameterInstances);

      if (serviceDescriptor.Lifetime == Lifetime.Singleton)
        serviceDescriptor.Implementation = implementation;

      return implementation;
    }

    public T GetService<T>()
    {
      return (T)GetService(typeof(T));
    }

  }

  public static class Program
  {
    public static void Main()
    {
      var di = new DependencyInjection();
      di.AddDependency<IPrinterStarter, PrinterStarter>(Lifetime.Singleton);
      di.AddDependency<IHelloWorld, HelloWorld>();
      di.AddDependency<IMyName, MyName>();

      var myNameService = di.GetService<IMyName>();
      myNameService.PrintName();

      var helloWorldService = di.GetService<IHelloWorld>();
      helloWorldService.PrintMessage();
    }
  }
}

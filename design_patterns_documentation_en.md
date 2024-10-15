
# Design Patterns Documentation in C#

This documentation lists the main Design Patterns, explaining their structure, usage, and providing C# code examples for each.

---

## 1. Singleton Pattern
Ensures that a class has only one instance and provides a global point of access to it.

**Usage:**
- Used when only one instance of a class is needed (e.g., configuration manager, logging).

**Code Example:**
```csharp
public class Singleton
{
    private static Singleton _instance;

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
```

---

## 2. Factory Pattern
Defines an interface for creating objects but lets subclasses alter the type of objects that will be created.

**Usage:**
- Used when the exact type of object cannot be determined until runtime.

**Code Example:**
```csharp
public abstract class Product { }
public class ConcreteProductA : Product { }
public class ConcreteProductB : Product { }

public abstract class Creator
{
    public abstract Product FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductB();
    }
}
```

---

## 3. Observer Pattern
Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified.

**Usage:**
- Used in event handling systems like UI frameworks or messaging systems.

**Code Example:**
```csharp
public interface IObserver
{
    void Update();
}

public class ConcreteObserver : IObserver
{
    public void Update()
    {
        Console.WriteLine("Observer updated!");
    }
}

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}
```

---

## 4. Strategy Pattern
Defines a family of algorithms, encapsulates each one, and makes them interchangeable.

**Usage:**
- Used when multiple algorithms can be applied to solve a problem and the client should choose one.

**Code Example:**
```csharp
public interface IStrategy
{
    void Execute();
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Strategy A executed");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Strategy B executed");
    }
}

public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}
```

---

## 5. Decorator Pattern
Allows behavior to be added to an individual object, dynamically, without affecting the behavior of other objects from the same class.

**Usage:**
- Used when you want to add responsibilities to individual objects without modifying their structure.

**Code Example:**
```csharp
public abstract class Component
{
    public abstract void Operation();
}

public class ConcreteComponent : Component
{
    public override void Operation()
    {
        Console.WriteLine("ConcreteComponent Operation");
    }
}

public abstract class Decorator : Component
{
    protected Component _component;

    public Decorator(Component component)
    {
        _component = component;
    }

    public override void Operation()
    {
        _component.Operation();
    }
}

public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(Component component) : base(component) { }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorA Operation");
    }
}
```

---

## 6. Adapter Pattern
Converts the interface of a class into another interface clients expect. Adapter lets classes work together that couldn’t otherwise because of incompatible interfaces.

**Usage:**
- Used when you want to integrate classes with different interfaces into an existing system.

**Code Example:**
```csharp
public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Specific Request");
    }
}

public class Adapter : ITarget
{
    private Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}
```

---

## 7. Command Pattern
Encapsulates a request as an object, thereby allowing for parameterizing clients with queues, requests, and operations.

**Usage:**
- Used to implement undoable operations or transactional systems.

**Code Example:**
```csharp
public interface ICommand
{
    void Execute();
}

public class ConcreteCommand : ICommand
{
    private Receiver _receiver;

    public ConcreteCommand(Receiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Action();
    }
}

public class Receiver
{
    public void Action()
    {
        Console.WriteLine("Action executed");
    }
}

public class Invoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}
```

---

## 8. Facade Pattern
Provides a simplified interface to a complex subsystem.

**Usage:**
- Used to hide complexity and provide a simple interface.

**Code Example:**
```csharp
public class SubsystemA
{
    public void OperationA() => Console.WriteLine("Operation A");
}

public class SubsystemB
{
    public void OperationB() => Console.WriteLine("Operation B");
}

public class Facade
{
    private SubsystemA _subsystemA;
    private SubsystemB _subsystemB;

    public Facade()
    {
        _subsystemA = new SubsystemA();
        _subsystemB = new SubsystemB();
    }

    public void Operation()
    {
        _subsystemA.OperationA();
        _subsystemB.OperationB();
    }
}
```

---

## 9. Proxy Pattern
Provides a surrogate or placeholder for another object to control access to it.

**Usage:**
- Used when you want to control access to an object.

**Code Example:**
```csharp
public interface ISubject
{
    void Request();
}

public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("Real Subject Request");
    }
}

public class Proxy : ISubject
{
    private RealSubject _realSubject;

    public void Request()
    {
        if (_realSubject == null)
        {
            _realSubject = new RealSubject();
        }
        _realSubject.Request();
    }
}
```

---

## 10. Template Method Pattern
Defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps without changing the algorithm’s structure.

**Usage:**
- Used when multiple classes share the same behavior but differ in specific steps.

**Code Example:**
```csharp
public abstract class AbstractClass
{
    public void TemplateMethod()
    {
        StepOne();
        StepTwo();
    }

    public abstract void StepOne();
    public abstract void StepTwo();
}

public class ConcreteClassA : AbstractClass
{
    public override void StepOne() => Console.WriteLine("Step One in ConcreteClassA");
    public override void StepTwo() => Console.WriteLine("Step Two in ConcreteClassA");
}

public class ConcreteClassB : AbstractClass
{
    public override void StepOne() => Console.WriteLine("Step One in ConcreteClassB");
    public override void StepTwo() => Console.WriteLine("Step Two in ConcreteClassB");
}
```

---

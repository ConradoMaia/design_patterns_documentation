
# Documentação de Padrões de Projeto em C#

Esta documentação lista os principais Padrões de Projeto, explicando sua estrutura, uso e fornecendo exemplos de código em C# para cada um.

---

## 1. Padrão Singleton
Garante que uma classe tenha apenas uma instância e fornece um ponto de acesso global para ela.

**Uso:**
- Utilizado quando é necessário apenas uma instância de uma classe (por exemplo, gerenciador de configuração, log).

**Exemplo de Código:**
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

## 2. Padrão Factory
Define uma interface para criar objetos, mas permite que subclasses alterem o tipo de objeto a ser criado.

**Uso:**
- Utilizado quando o tipo exato de objeto não pode ser determinado até o tempo de execução.

**Exemplo de Código:**
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

## 3. Padrão Observer
Define uma dependência de um-para-muitos entre objetos, de modo que, quando um objeto muda de estado, todos os seus dependentes são notificados.

**Uso:**
- Utilizado em sistemas de manipulação de eventos, como frameworks de interface gráfica ou sistemas de mensagens.

**Exemplo de Código:**
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

## 4. Padrão Strategy
Define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis.

**Uso:**
- Utilizado quando múltiplos algoritmos podem ser aplicados para resolver um problema e o cliente deve escolher um.

**Exemplo de Código:**
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

## 5. Padrão Decorator
Permite adicionar comportamentos a um objeto individual, dinamicamente, sem afetar o comportamento de outros objetos da mesma classe.

**Uso:**
- Utilizado quando se deseja adicionar responsabilidades a objetos individuais sem modificar sua estrutura.

**Exemplo de Código:**
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

## 6. Padrão Adapter
Converte a interface de uma classe em outra interface esperada pelos clientes. O Adapter permite que classes trabalhem juntas, apesar de interfaces incompatíveis.

**Uso:**
- Utilizado quando se deseja integrar classes com diferentes interfaces em um sistema existente.

**Exemplo de Código:**
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

## 7. Padrão Command
Encapsula uma solicitação como um objeto, permitindo parametrizar clientes com filas, solicitações e operações.

**Uso:**
- Utilizado para implementar operações que podem ser desfeitas ou sistemas transacionais.

**Exemplo de Código:**
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

## 8. Padrão Facade
Fornece uma interface simplificada para um subsistema complexo.

**Uso:**
- Utilizado para esconder a complexidade e fornecer uma interface simples.

**Exemplo de Código:**
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

## 9. Padrão Proxy
Fornece um substituto ou representante para outro objeto para controlar o acesso a ele.

**Uso:**
- Utilizado quando se deseja controlar o acesso a um objeto.

**Exemplo de Código:**
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

## 10. Padrão Template Method
Define a estrutura de um algoritmo na superclasse, mas permite que as subclasses sobrescrevam etapas específicas sem alterar a estrutura do algoritmo.

**Uso:**
- Utilizado quando múltiplas classes compartilham o mesmo comportamento, mas diferem em etapas específicas.

**Exemplo de Código:**
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

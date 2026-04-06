namespace CS.Assignment3;

public class Student : Person
{
    public override string Greet(){return "Hi, I'm a student!";}
    public string Study(){return "I'm studying!";}
    public string ShowAge(){return $"I am {Age} years old.";}
}


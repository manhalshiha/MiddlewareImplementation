using MiddlewareImplementation.SortingApp;

var app = new SortingApp();
var numbers = new List<int> { 1, 2, 4, 8, 3 };

app.Use((context, next) =>
{
	Console.WriteLine("First registered middleware , Exception handling");
	try
	{
		return next;
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
		throw;
	}
});
app.Use((context, next) =>
{
	Console.WriteLine("Second registered middleware, changing the middleware");
	context.Algorithm = SortingAlgorithm.SelectionSort;
	return next;
});
app.Use((context, next) =>
{
	Console.WriteLine("Add a number during execution ");
	context.Request.Add(10);
	return (next);
});
app.Sort(numbers);
app.Context.Response.ForEach((number) =>
{
	Console.WriteLine($"{number}");
});


//public class Program
//{
//    // Define a delegate that takes an int and returns an int
//    public delegate int Transformer(int x);

//    public static void Main()
//    {
//        // Instantiate the delegate with a lambda expression
//       Transformer FirstStep = num => num * num;

//        // Pass the delegate as a parameter and get a new delegate
//        Transformer SecondStep = ApplyAndDouble(FirstStep);

//        Transformer ThirdStep = ApplySum(1, 2);


//        // Use the new delegate
//        int result = ThirdStep(3);
//        Console.WriteLine(result); // Output will be 18
//    }

//    // This function takes a Transformer delegate as a parameter
//    // and returns a new Transformer delegate
//    public static Transformer ApplyAndDouble(Transformer transformer)
//    {
//        // The new delegate takes an int 'x', applies the passed delegate,
//        // and then doubles the result
//        return x => 2 * transformer(x);
//    }
//    public static Transformer ApplySum(int firstStep,int secondStrep)=> x => 5;

//}
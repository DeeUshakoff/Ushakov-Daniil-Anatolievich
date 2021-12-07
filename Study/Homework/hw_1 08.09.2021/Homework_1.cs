
namespace Study
{
    public class Homework_1
    {
		public void Task_2()
		{
			Console.WriteLine("---Task 2---");
			Console.WriteLine("Enter the num: ");

			try
			{
				int x = Int32.Parse(Console.ReadLine());

				int u = x * x; // x^2
				int v = u * x; // x^3
				int w = v * u; // x^5

				double y = (w + 5.7 * v) / (u - 7.5) + 4.2 * w - 8.9 * u;

				Console.WriteLine("y = " + y.ToString());
			}
			catch (FormatException)
			{
				Console.WriteLine("Print num instead text");
			}

		}

		public void Task_3()
		{
			Console.WriteLine("---Task 3---");
			try
			{
				Console.WriteLine("Enter the num");
				double x = Double.Parse(Console.ReadLine());

				double y = (x + 4) * (1 + (x + 3) * (1 + (x + 2) * (1 + (x + 2) * (1 + (x + 1)))));

				Console.WriteLine("y = " + y.ToString());
			}
			catch (FormatException)
			{
				Console.WriteLine("Enter the num instead text");
			}

		}

		public void Task_4()
		{
			Console.WriteLine("---Task 4---");
			try
			{
				Console.WriteLine("Enter a:");
				double a = Double.Parse(Console.ReadLine());

				Console.WriteLine("Enter b:");
				double b = Double.Parse(Console.ReadLine());

				Console.WriteLine("Enter c:");
				double c = Double.Parse(Console.ReadLine());

				double abc = a * b * c;
				double fraction = (a + b + c) / 3;

				double min;

				if (fraction > abc)
				{
					min = abc;
				}
				else
				{
					min = fraction;
				}

				double y = min / (1 + min * min);

				Console.WriteLine("y = " + y.ToString());
			}
			catch (FormatException)
			{
				Console.WriteLine("Enter the num instead text");
			}

		}

		public void Task_5()
		{
			Console.WriteLine("---Task 5---");
			try
			{
				Console.WriteLine("Enter k:");
				double k = Double.Parse(Console.ReadLine());

				Console.WriteLine("Enter i:");
				double i = Double.Parse(Console.ReadLine());

				Console.WriteLine("Enter t:");
				double t = Double.Parse(Console.ReadLine());

				double n;
				if (k == i && k == t)
				{
					Console.WriteLine("Every nums are the same");
				}
				else if (k == i)
				{
					n = t;
					Console.WriteLine("n = " + n.ToString());
				}
				else if (k == t)
				{
					n = i;
					Console.WriteLine("n = " + n.ToString());
				}
				else if (t == i)
				{
					n = k;
					Console.WriteLine("n = " + n.ToString());
				}
				else
				{
					Console.WriteLine("Every nums are different");
				}
			}
			catch (FormatException)
			{
				Console.WriteLine("Print num instead text");
			}

			Console.ReadLine();

		}
		
	}
}

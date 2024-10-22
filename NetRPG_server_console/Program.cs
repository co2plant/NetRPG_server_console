using NetRPG_server_console;

public class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[24000];
        arr[0] = 4;
        int cons = 4;
        int count = 0;
        for (int i = 1; i < 24000; i++)
        {
            cons += 4;
            arr[i] = arr[i - 1] + cons;
        }
        int inputN = int.Parse(Console.ReadLine());
        

        for (int i = 0; i < inputN; i++)
        {
            int inputM = int.Parse(Console.ReadLine());
            int j = 0;
            while (true)
            {
                if (((inputM - arr[j])/(j*2+3))==0)
                {
                    break;
                }
                if(inputM<1152048000)
                
                if (inputM < arr[j] || inputM>1152048000)
                {
                    count += 1;
                    break;
                }

                
                j++;
            }
        }

        Console.WriteLine(count);
    }
}
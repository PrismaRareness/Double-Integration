using System;
  
class doubleIntegralRun
{

static float givenFunction(float x, float y)
{
        return (float) Math.Pow(Math.Pow(x, 4) + 
                            Math.Pow(y, 5), 0.5);
    }
      
    static float doubleIntegral(float h, float k,
                        float lx, float ux,
                        float ly, float uy)
    {
        int nx, ny;

        float [, ] z = new float[50, 50];
        float [] ax = new float[50];
        float answer;

        nx = (int) ((ux - lx) / h + 1);
        ny = (int) ((uy - ly) / k + 1);
      
        for (int i = 0; i < nx; ++i)
        {
            for (int j = 0; j < ny; ++j) 
            {
                z[i, j] = givenFunction(lx + i * h,
                                        ly + j * k);
            }
        }

        for (int i = 0; i < nx; ++i) 
        {
            ax[i] = 0;
            for (int j = 0; j < ny; ++j)
            {
                if (j == 0 || j == ny - 1)
                    ax[i] += z[i, j];
                else if (j % 2 == 0)
                    ax[i] += 2 * z[i, j];
                else
                    ax[i] += 4 * z[i, j];
            }
            ax[i] *= (k / 3);
        }
      
        answer = 0;
      
        for (int i = 0; i < nx; ++i)
        {
            if (i == 0 || i == nx - 1)
                answer += ax[i];
            else if (i % 2 == 0)
                answer += 2 * ax[i];
            else
                answer += 4 * ax[i];
        }
        answer *= (h / 3);
      
        return answer;
    }
      
    public static void Main()
    {
        float h, k, lx, ux, ly, uy;
      
        lx = (float) 2.3; ux = (float) 2.5; ly = (float) 3.7;
        uy = (float) 4.3; h = (float) 0.1; k = (float) 0.15;
      
        Console.WriteLine(doubleIntegral(h, k, lx, ux, ly, uy));
    }
}
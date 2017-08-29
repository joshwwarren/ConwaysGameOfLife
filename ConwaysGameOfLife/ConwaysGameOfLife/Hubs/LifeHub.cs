using System.Linq;
using ConwaysGameOfLife.Models.Matrix;
using Microsoft.AspNet.SignalR;

namespace ConwaysGameOfLife.Hubs
{
    public class LifeHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("hello");
        }

        public void CreateMatrix(int sideLength = 50)
        {
            var newMatrix = new Matrix().CreateNewMatrix(sideLength);
            Clients.All.pushMatrix(newMatrix);
        }

        public void Judge(Matrix matrix)
        {
            var newMatrix = new Matrix().JudgeMatrix(matrix);
            while (newMatrix.Rows.Any(a => a.Cells.Any(c => c.IsAlive)))
            {
                Clients.All.pushMatrix(newMatrix);
                newMatrix = new Matrix().JudgeMatrix(matrix);
            }
        }
    }
}
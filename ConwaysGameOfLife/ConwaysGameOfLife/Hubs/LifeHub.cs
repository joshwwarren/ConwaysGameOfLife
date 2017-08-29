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
            Clients.All.pushMatrix(newMatrix);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly_Catching_Game_MOO_ICT
{
    internal class Joaninha
    {
        public Image ladybug_image;
        public int positionX;
        public int positionY;
        public int height;
        public int width;
        public int speedX, speedY, limit, moveLimit;
        Random rand = new Random();
        public int lifeTime; // nova propriedade
        public Joaninha()
        {
            limit = rand.Next(150, 300); // Joaninha pode mudar direção mais rápido
            moveLimit = limit;

            speedX = rand.Next(-5, 5);  
            speedY = rand.Next(-5, 5);

            height = 40; // tamanho menor que a borboleta
            width = 40;

            lifeTime = rand.Next(200, 500);
        }

        public void MoveJoaninha()
        {
            moveLimit--;

            if (moveLimit <= 0)
            {
                speedX = rand.Next(-5, 5);
                speedY = rand.Next(-5, 5);
                moveLimit = rand.Next(150, limit);
            }

            lifeTime--; // diminui a vida a cada movimento
        }


        public bool IsDead()
        {
            return lifeTime <= 0;
        }
    }
}

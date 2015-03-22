using System.Collections.Generic;
using System.Linq;

namespace KKogut.ChangeProblem
{
    public class GreedyChange
    {
        private List<int> coins;

        public GreedyChange()
        {
            coins = new List<int>();
        }

        public void RegisterCoin(int coin)
        {
            coins.Add(coin);
        }

        public void RegisterCoins(int[] coins)
        {
            this.coins.AddRange(coins);
        }

        public int[] GetChangeFor(int changeToMake)
        {
            var result = new List<int>();
            coins.Sort(new DescIntComparer());
            while (changeToMake > 0)
            {
                result.Add(coins.First(c => c <= changeToMake));
                changeToMake -= result.Last();
            }
            return result.ToArray();
        }
    }

    class DescIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
                return -1;
            if (x < y)
                return 1;
            return 0;
        }
    }
}

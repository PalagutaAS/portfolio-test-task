using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static List<T> Shuffle<T>(this List<T> inputList)
    {
        var rnd = new System.Random();
        List<T> shuffleList = new List<T>();
        var randomized = inputList.OrderBy(item => rnd.Next());
        foreach (var item in randomized)
        {
            shuffleList.Add(item);
        }
        return shuffleList;
    }
}

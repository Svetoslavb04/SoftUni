namespace _04._MeTube_Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var videos = new Dictionary<string, int>();
            var likes = new Dictionary<string, int>();

            while (true)
            {
                var splitor = new char[] { '-', ':' };
                var input = Console.ReadLine().Split(splitor, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "stats time")
                {
                    var orderer = Console.ReadLine();
                    if (orderer == "by views")
                    {
                        foreach (var video in videos.OrderByDescending(v => v.Value))
                        {
                            Console.WriteLine($"{video.Key} - {video.Value} views - {likes[video.Key]} likes");
                        }
                        break;
                    }
                    else if (orderer == "by likes")
                    {
                        foreach (var video in likes.OrderByDescending(v => v.Value))
                        {
                            Console.WriteLine($"{video.Key} - {videos[video.Key]} views - {video.Value} likes");
                        }
                        break;
                    }
                    break;
                }

                if (input[0] == "like" || input[0] == "dislike")
                {
                    if (likes.ContainsKey(input[1]))
                    {
                        if (input[0] == "like")
                        {
                            likes[input[1]]++;
                        }
                        else if (input[0] == "dislike")
                        {
                            likes[input[1]]--;
                        }
                    }
                    continue;
                }
                if (videos.ContainsKey(input[0]))
                {
                    videos[input[0]] += int.Parse(input[1]);
                }
                else
                {
                    videos.Add(input[0], int.Parse(input[1]));
                    likes.Add(input[0], 0);
                }
            }
        }
    }
}

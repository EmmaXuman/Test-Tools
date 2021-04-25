using System;
using System.Linq;

namespace ef_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BaseDbContext();
            //添加
            context.Add(new ModelA { Id = 10, Name = "测试" });
            context.SaveChanges();//保存数据到数据库中
                                  //查询
            var modelA = context.ModelAs.Where(p => p.Id > 1).First();
            //更新
            modelA.Name += DateTime.Now;
            context.SaveChanges();
            //删除
            context.Remove(modelA);
            context.SaveChanges();
            context.Dispose();
            Console.WriteLine("Hello World!");
        }
    }
}

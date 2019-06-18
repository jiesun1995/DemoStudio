using Interfaces;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{    
    public class MathGrain : Grain, IMath
    {
        private int num = 0;
        public async Task AddAsync()
        {
            num++;
            //await WriteStateAsync();
            await Task.CompletedTask;
        }

        public async Task<int> CountAsync()
        {
            var count = num;
            //await ReadStateAsync();
            await Task.CompletedTask;
            return count;
        }
    }
    public class MathArchive
    {
        public int Count { set; get; } = 0;
    }
}

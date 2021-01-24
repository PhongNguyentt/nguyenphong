using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pikachu", Description="This is an Electric-type Pokemon.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Snorlax", Description="This is the heaviest Pokemon.", Value=10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Charmander", Description="This is a Fire-type Lizard Pokemon.", Value=8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Bulbasaur", Description="This is a Grass/Poison-type Seed Pokemon.", Value=7 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Squirtle", Description="This is a Water-type Pokemon.", Value=6 }
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
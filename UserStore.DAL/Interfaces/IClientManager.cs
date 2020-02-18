using Forum_Marchuk.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Forum_Marchuk.DAL.Interfaces
{
    public interface IClientManager:IDisposable
    {
        void Create(ClientProfile item);
    }
}

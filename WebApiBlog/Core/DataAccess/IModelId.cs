using System;

namespace WebApiBlog.Core.DataAccess
{
    public interface IModelId
    {
        Guid Id { get; }
    }
}
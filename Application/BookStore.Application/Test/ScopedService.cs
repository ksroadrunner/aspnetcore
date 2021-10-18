using System;
using BookStore.Application.Abstractions.Test;

namespace BookStore.Application.Test
{
    public class ScopedService : IScopedService
    {
        private readonly string Identity = Guid.NewGuid().ToString();

        public string Generate()
            => this.Identity;
    }
}
﻿using System;

using Stove.Bootstrapping;
using Stove.Bootstrapping.Bootstrappers;
using Stove.Redis.Redis;

namespace Stove.Redis
{
    [DependsOn(
        typeof(StoveKernelBootstrapper)
    )]
    public class StoveRedisBootstrapper : StoveBootstrapper
    {
        public override void PreStart()
        {
            if (Resolver.IsRegistered<Func<StoveRedisCacheOptions, StoveRedisCacheOptions>>())
            {
                var cacheConfigurer = Resolver.Resolve<Func<StoveRedisCacheOptions, StoveRedisCacheOptions>>();
                Configuration.Caching.UseRedis(options => cacheConfigurer(options));
            }
        }
    }
}
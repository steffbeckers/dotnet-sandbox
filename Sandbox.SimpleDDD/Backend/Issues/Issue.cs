﻿using System;
using GoldenEye.Backend.Core.DDD.Aggregates;
using GoldenEye.Shared.Core.Objects.General;
using Sandbox.SimpleDDD.Contracts.Issues;

namespace Sandbox.SimpleDDD.Backend.Issues
{
    public class Issue : IAggregate
    {
        object IHasId.Id => Id;

        public Guid Id { get; set; }

        public IssueType Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Issue()
        {
        }

        public Issue(Guid id, IssueType type, string title, string description)
        {
            Id = id;
            Type = type;
            Title = title;
            Description = description;
        }

        public void Update(IssueType type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }
    }
}
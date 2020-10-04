﻿using System;
using GoldenEye.Backend.Core.DDD.Events;

namespace Sandbox.SimpleDDD.Contracts.Issues.Events
{
    public class IssueUpdated : IEvent
    {
        public Guid IssueId { get; }

        public IssueType Type { get; }

        public string Title { get; }

        public string Description { get; }

        public Guid StreamId => IssueId;

        public IssueUpdated(Guid issueId, IssueType type, string title, string description)
        {
            IssueId = issueId;
            Type = type;
            Title = title;
            Description = description;
        }
    }
}
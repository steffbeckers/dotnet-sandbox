﻿using System;
using Sandbox.SimpleDDD.Contracts.Issues;
using Sandbox.SimpleDDD.Contracts.Issues.Events;
using Sandbox.SimpleDDD.Contracts.Issues.Views;
using Marten.Events.Projections;

namespace Sandbox.SimpleDDD.Backend.Issues.Projections
{
    internal class IssueProjection : ViewProjection<IssueView, Guid>
    {
        public Guid Id { get; set; }

        public IssueType Type { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IssueProjection()
        {
            ProjectEvent<IssueCreated>(ev => ev.IssueId, (item, @event) => item.Apply(@event));
            ProjectEvent<IssueUpdated>(ev => ev.IssueId, (item, @event) => item.Apply(@event));
            DeleteEvent<IssueDeleted>(ev => ev.IssueId);
        }

        private void Apply(IssueView item, IssueCreated @event)
        {
            Id = @event.IssueId;
            Type = @event.Type;
            Title = @event.Title;
            Description = @event.Description;
        }

        private void Apply(IssueView item, IssueUpdated @event)
        {
            Type = @event.Type;
            Title = @event.Title;
            Description = @event.Description;
        }
    }
}
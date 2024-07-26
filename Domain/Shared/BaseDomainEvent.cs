﻿namespace Domain.Shared;

public class BaseDomainEvent
{
    public DateTime CreationDate { get; protected set; }
    public BaseDomainEvent()
    {
        CreationDate = new DateTime();
    }
}

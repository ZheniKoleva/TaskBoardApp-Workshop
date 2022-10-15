﻿namespace TaskBoardApp.Core.Models;

public class BoardViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
}

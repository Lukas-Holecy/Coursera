// This file contains the entry point of the Library Management System application.
// It uses a feature called top-level statements, which allows you to omit the Main method.
using Holecy.Coursera.Microsoft.LibraryManagement;

/// <summary>
/// Entry point of the Library Management System application.
/// Creates a new menu with a default reader and starts the application.
/// </summary>
var menu = new Menu(new Library());
menu.Run();
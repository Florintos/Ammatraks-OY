using Ammatraks_OY.Model;
using System.Collections.Generic;
using System.IO;
using System.Windows;

public class UserManager
{
    private List<User> users;

    public UserManager()
    {
        users = new List<User>();
        LoadUsersFromCsv();
    }

    private void LoadUsersFromCsv()
    {
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string csvFilePath = Path.Combine(appDirectory, "..", "..", "..", "Users.csv");

        try
        {
            if (File.Exists(csvFilePath))
            {
                string[] lines = File.ReadAllLines(csvFilePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 6) // ID, Name, PhoneNumber, Email, Username, Password
                    {
                        int id;
                        if (int.TryParse(parts[0], out id))
                        {
                            string name = parts[1];
                            string phoneNumber = parts[2];
                            string email = parts[3];
                            string username = parts[4];
                            string password = parts[5];

                            // Check if the user is an admin or worker based on ID prefix
                            if (id >= 1000 && id < 2000)
                            {
                                users.Add(new Admin { ID = id, Name = name, PhoneNumber = phoneNumber, Email = email, Username = username, Password = password });
                            }
                            else if (id >= 2000)
                            {
                                users.Add(new Worker { ID = id, Name = name, PhoneNumber = phoneNumber, Email = email, Username = username, Password = password });
                            }
                        }
                    }
                }
            }
        }
        catch (Exception error)
        {
            MessageBox.Show($"Error loading data from CSV file: {error.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public User Authenticate(string username, string password)
    {
        return users.Find(user => user.Username == username && user.Password == password);
    }

}    
    
using System.Diagnostics;
using System.Drawing;

namespace Lab2AssignmentLauncher;

public sealed class AppPickerForm : Form
{
    private readonly string repositoryRoot;
    private readonly string configuration;
    private readonly Label statusLabel;

    public AppPickerForm(string? rootOverride = null)
    {
        repositoryRoot = rootOverride ?? FindRepositoryRoot();
        configuration = new DirectoryInfo(Path.TrimEndingDirectorySeparator(AppContext.BaseDirectory)).Parent?.Name ?? "Debug";

        Text = "Lab 2 Projects";
        ClientSize = new Size(820, 500);
        MinimumSize = new Size(820, 500);
        MaximumSize = new Size(820, 500);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(244, 247, 250);
        Font = new Font("Segoe UI", 10F);

        var heading = new Label
        {
            Text = "Choose an app",
            Font = new Font("Segoe UI", 25F, FontStyle.Bold),
            ForeColor = Color.FromArgb(26, 42, 61),
            AutoSize = true,
            Location = new Point(42, 36)
        };
        Controls.Add(heading);

        var subtitle = new Label
        {
            Text = "Select which Lab 2 project you want to open.",
            Font = new Font("Segoe UI", 11F),
            ForeColor = Color.FromArgb(83, 100, 119),
            AutoSize = true,
            Location = new Point(46, 88)
        };
        Controls.Add(subtitle);

        Controls.Add(CreateCard(
            "Bicycle Rental Calculator",
            "Enter the rental start and end hours to calculate the total cost in RWF.",
            "Open bicycle app",
            Color.FromArgb(36, 101, 166),
            () => LaunchProject("Lab2", "Lab2")));

        Controls.Add(CreateCard(
            "Mushroom Identifier",
            "Answer a few yes-or-no questions to identify one of the mushrooms in the list.",
            "Open mushroom app",
            Color.FromArgb(36, 130, 104),
            () => LaunchProject("mushroom", "mushroom"),
            new Point(423, 155)));

        statusLabel = new Label
        {
            Text = "Choose either project to continue.",
            AutoSize = true,
            ForeColor = Color.FromArgb(83, 100, 119),
            Location = new Point(46, 423)
        };
        Controls.Add(statusLabel);
    }

    private static Panel CreateCard(string title, string description, string buttonText, Color accent, Action onClick, Point? location = null)
    {
        var card = new Panel
        {
            Location = location ?? new Point(42, 155),
            Size = new Size(355, 238),
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };

        card.Controls.Add(new Label
        {
            Text = title,
            Font = new Font("Segoe UI", 15F, FontStyle.Bold),
            ForeColor = Color.FromArgb(26, 42, 61),
            AutoSize = true,
            Location = new Point(22, 24)
        });

        card.Controls.Add(new Label
        {
            Text = description,
            Font = new Font("Segoe UI", 10F),
            ForeColor = Color.FromArgb(83, 100, 119),
            Location = new Point(24, 71),
            Size = new Size(300, 63)
        });

        var openButton = new Button
        {
            Text = buttonText,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = accent,
            FlatStyle = FlatStyle.Flat,
            Location = new Point(24, 160),
            Size = new Size(300, 42),
            Cursor = Cursors.Hand
        };
        openButton.FlatAppearance.BorderSize = 0;
        openButton.Click += (_, _) => onClick();
        card.Controls.Add(openButton);

        return card;
    }

    private void LaunchProject(string projectFolder, string executableName)
    {
        var executable = Path.Combine(repositoryRoot, projectFolder, "bin", configuration, "net10.0-windows", executableName + ".exe");
        if (!File.Exists(executable))
        {
            statusLabel.Text = "The app could not be found. Start this launcher with dotnet run to build both projects.";
            return;
        }

        try
        {
            var child = Process.Start(new ProcessStartInfo
            {
                FileName = executable,
                WorkingDirectory = repositoryRoot,
                UseShellExecute = true
            });

            if (child is null)
            {
                statusLabel.Text = "Windows could not open that app. Please try again.";
                return;
            }

            Hide();
            child.EnableRaisingEvents = true;
            child.Exited += (_, _) =>
            {
                if (!IsDisposed && IsHandleCreated)
                {
                    BeginInvoke((Action)(() =>
                    {
                        Show();
                        Activate();
                    }));
                }
                child.Dispose();
            };
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Could not open the selected app: {ex.Message}";
        }
    }

    private static string FindRepositoryRoot()
    {
        for (var directory = new DirectoryInfo(AppContext.BaseDirectory); directory is not null; directory = directory.Parent)
        {
            if (File.Exists(Path.Combine(directory.FullName, "Lab2.slnx")))
                return directory.FullName;
        }

        throw new DirectoryNotFoundException("Could not find Lab2.slnx above the launcher.");
    }
}




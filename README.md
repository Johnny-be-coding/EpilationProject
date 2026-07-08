# EpilationProject - Client Manager Documentation

## Table of Contents
1. [Overview](#overview)
2. [Features](#features)
3. [System Requirements](#system-requirements)
4. [Installation](#installation)
5. [User Guide](#user-guide)
6. [Procedure Scheduling Logic](#procedure-scheduling-logic)
7. [Email Notifications](#email-notifications)
8. [Configuration](#configuration)
9. [Data Management](#data-management)
10. [Architecture](#architecture)
11. [Troubleshooting](#troubleshooting)
12. [FAQ](#faq)

---

## Overview

**EpilationProject** is a Windows Forms desktop application designed to manage laser hair removal (epilation) clients and their treatment schedules. It helps clinics and practitioners track client information, calculate optimal procedure schedules based on service type, and send automated email reminders for upcoming appointments.

### Purpose
- Centralize client database management
- Automate procedure scheduling based on service-specific intervals
- Send email reminders 15 days before scheduled procedures
- Track procedure history for each client

### Target Users
- Epilation clinics
- Individual practitioners
- Medical aesthetic professionals

---

## Features

### 1. **Client Management**
- ✅ Add new clients with full information
- ✅ Update existing client details
- ✅ Delete clients from the system
- ✅ Search and view all clients in a list
- ✅ Store client contact information and procedure details

### 2. **Smart Procedure Scheduling**
- ✅ Automatic calculation of next procedure dates
- ✅ Service-specific scheduling intervals (Face, Body, Legs)
- ✅ Progressive interval changes after 6 procedures
- ✅ Annual reminders after 8 procedures
- ✅ Manual procedure count tracking

### 3. **Email Notifications**
- ✅ Automated reminder emails 15 days before procedures
- ✅ HTML-formatted emails with client details
- ✅ Gmail SMTP integration
- ✅ Bulk notification sending
- ✅ Secure credential management

### 4. **Data Persistence**
- ✅ Local CSV-based data storage
- ✅ Automatic backup locations
- ✅ Settings persistence
- ✅ No database server required

### 5. **User-Friendly Interface**
- ✅ Intuitive Windows Forms UI
- ✅ Real-time client list display
- ✅ Form validation with helpful error messages
- ✅ Clear field labels and organization

---

## System Requirements

### Minimum Requirements
- **OS**: Windows 7 or later (Windows 10/11 recommended)
- **Framework**: .NET Framework 4.8
- **.NET Version**: Desktop support
- **RAM**: 512 MB minimum (1 GB recommended)
- **Storage**: 100 MB free space

### Internet Requirements
- Internet connection for email notifications
- Access to Gmail SMTP server (smtp.gmail.com, port 587)
- Optional: SSL/TLS support enabled

---

## Installation

### Step 1: System Requirements
Ensure your Windows system has .NET Framework 4.8 installed.

**To check/install .NET Framework 4.8:**
1. Go to: https://dotnet.microsoft.com/download/dotnet-framework/net48
2. Download and install "Runtime" or "Developer Pack"
3. Restart your computer

### Step 2: Application Setup
1. Extract `EpilationProject.exe` to your desired location
   - Recommended: `C:\Program Files\EpilationProject\`
   - Or: `C:\Users\[YourUsername]\AppData\Local\EpilationProject\`

2. Create a shortcut on your desktop (optional):
   - Right-click `EpilationProject.exe`
   - Select "Send to" → "Desktop (create shortcut)"

### Step 3: Launch
Double-click `EpilationProject.exe` to start the application.

**First Launch:**
- Settings directory will be created at: `%LocalAppData%\EpilationProject\`
- Data file will be created at: `%LocalAppData%\EpilationProject\data.csv`
- Settings file will be created at: `%LocalAppData%\EpilationProject\settings.txt`

---

## User Guide

### Adding a New Client

1. **Fill in Client Information:**
   - **Name**: Enter client's full name
   - **Phone**: Enter contact phone number
   - **Service**: Select one of:
	 - Процедура ЛИЦЕ (Face)
	 - Процедура ТОРС (Body/Trunk)
	 - Процедура КРАКА (Legs)
   - **Energy**: Enter energy level in J m/s (e.g., "20")
   - **Phototype**: Enter skin phototype (e.g., "III", "IV")
   - **First Procedure Date**: Select date of 1st procedure
   - **Procedure Count**: Enter number of completed procedures (e.g., "0" for new client)

2. **Click "Add" Button**

3. **Confirmation:**
   - Success message will appear
   - Client will appear in the list below
   - Form will clear for next entry

### Updating Client Information

1. **Select Client** from the list
   - Form fields will auto-populate with client data

2. **Modify Fields** as needed
   - Change any field (name, phone, service, procedure count, etc.)

3. **Click "Update" Button**

4. **Confirmation:**
   - Success message will appear
   - Changes are saved to database

### Deleting a Client

1. **Select Client** from the list

2. **Click "Delete" Button**

3. **Confirm Deletion:**
   - A confirmation dialog will appear
   - Click "Yes" to confirm or "No" to cancel

4. **Verification:**
   - Client will be removed from the list
   - Data is permanently deleted

### Viewing Clients

- All clients are displayed in the list at the bottom of the form
- Click any client to view/edit their details
- List is sorted alphabetically by default

### Form Validation

The application validates all inputs:
- **Name, Phone, Service**: Required fields
- **Procedure Count**: Must be a non-negative whole number
- **Date**: Must be valid and within DateTimePicker range

If validation fails, an error message explains what needs to be corrected.

---

## Procedure Scheduling Logic

### Overview
The app calculates the next procedure date based on:
- **Service type** (Face, Body, Legs)
- **Procedure count** (number of completed procedures)
- **Date of first procedure** (baseline date)

### Scheduling Intervals

Each service has three phases with different intervals:

#### Процедура ЛИЦЕ (Face/Facial)
```
Procedures 1-6:   30 days apart
Procedures 7-8:   40 days apart
Procedure 9+:     365 days (once yearly)
```

**Example:**
- Procedure 1: Jan 1, 2025
- Procedure 2: Jan 31, 2025 (+ 30 days)
- Procedure 3: Mar 2, 2025 (+ 30 days)
- Procedure 4: Apr 1, 2025 (+ 30 days)
- Procedure 5: May 1, 2025 (+ 30 days)
- Procedure 6: Jun 1, 2025 (+ 30 days)
- Procedure 7: Jul 11, 2025 (+ 40 days)
- Procedure 8: Aug 20, 2025 (+ 40 days)
- Procedure 9: Aug 20, 2026 (+ 365 days)

#### Процедура ТОРС (Body/Trunk)
```
Procedures 1-6:   45 days apart
Procedures 7-8:   60 days apart
Procedure 9+:     365 days (once yearly)
```

#### Процедура КРАКА (Legs)
```
Procedures 1-6:   60 days apart
Procedures 7-8:   90 days apart
Procedure 9+:     365 days (once yearly)
```

### How to Use Procedure Count

- **New Clients**: Set to `0`
- **After 1st Procedure**: Update to `1`
- **After 2nd Procedure**: Update to `2`
- etc.

The app automatically calculates the next procedure date based on the count.

### Viewing Calculated Dates

When you "Check Notifications", the upcoming procedures summary shows:
```
• Client Name - Procedure #4 on March 30, 2025 (Service Type)
```

This indicates:
- Next procedure is **#4** (2 completed = next is 3rd, but displays as #4)
- Scheduled for **March 30, 2025**
- For the selected **Service Type**

---

## Email Notifications

### Overview
The app sends HTML-formatted email reminders **15 days before** the calculated next procedure date.

### Setting Up Email Notifications

#### Step 1: Enable 2-Factor Authentication on Gmail
1. Go to: https://myaccount.google.com
2. Click "Security" (left sidebar)
3. Find "2-Step Verification" and enable it
4. Verify with your phone (SMS, authenticator app, or email)

#### Step 2: Generate App Password
1. Go to: https://myaccount.google.com/apppasswords
2. Select "Mail" and "Windows Computer"
3. Google generates a 16-character password
4. **Copy this password**

#### Step 3: Configure in EpilationProject
1. Click "Settings" button
2. Fill in:
   - **Epilation Person Name**: Your name (e.g., "Dr. Jane Smith")
   - **Epilation Person Email**: Email to receive reminders (your personal email)
   - **SMTP Server**: `smtp.gmail.com` (pre-filled)
   - **SMTP Port**: `587` (pre-filled)
   - **SMTP Username**: Your Gmail address (e.g., `clinic.email@gmail.com`)
   - **SMTP Password**: 16-character app password from Step 2
3. Click "Save Settings"

### Sending Notifications

1. Click "Check Notifications" button
2. App shows: "Upcoming procedures in the next 15 days:" with list
3. Review the list of clients with upcoming procedures
4. Click "Yes" to send emails or "No" to cancel

### Email Content

Clients receive emails with:
- Client name
- Phone number
- Service type
- Scheduled procedure date
- Energy level
- Phototype
- Professional greeting

**Email Format**: HTML table with formatted information

**Example Email Subject**: `Epilation Appointment Reminder - John Doe`

### Notification Criteria

An email is sent for a client if:
1. Their **next procedure date** (calculated) is within the next 15 days
2. Email settings are properly configured
3. The client has a valid service type assigned

---

## Configuration

### Settings Management

#### Accessing Settings
1. Click "Settings" button in main form
2. Settings form opens with configuration options

#### Email Settings

| Setting | Description | Example |
|---------|-------------|---------|
| Epilation Person Name | Your name/clinic name | "Dr. Smith" or "Epilation Clinic" |
| Epilation Person Email | Email to receive notifications | "clinic@email.com" |
| SMTP Server | Gmail SMTP server | `smtp.gmail.com` |
| SMTP Port | Port for TLS connection | `587` |
| SMTP Username | Gmail account email | `your.clinic@gmail.com` |
| SMTP Password | 16-character app password | `abcd efgh ijkl mnop` |

#### Saving Configuration
- Click "Save Settings"
- Success message confirms save
- Settings persist between application restarts

#### Default Values
```
SMTP Server: smtp.gmail.com
SMTP Port: 587
SSL/TLS: Enabled (automatic)
```

### Settings Storage
- Location: `%LocalAppData%\EpilationProject\settings.txt`
- Format: Plain text with key-value pairs
- Encryption: None (consider securing access to this file)

---

## Data Management

### Data Storage

#### File Location
- **Data File** (Clients): `%LocalAppData%\EpilationProject\data.csv`
- **Settings File**: `%LocalAppData%\EpilationProject\settings.txt`

#### Data Format (CSV)
```
ID|Name|Phone|Service|Energy|Phototype|DateOfFirstProcedure|ProcedureCount
1|John Doe|123-456-7890|Процедура ЛИЦЕ|20|III|2025-01-15|3
```

**Fields:**
- **ID**: Unique client identifier (auto-generated)
- **Name**: Client's full name
- **Phone**: Contact phone number
- **Service**: Service type (LICE/TORS/KRAKA)
- **Energy**: Energy level (J m/s)
- **Phototype**: Skin type classification
- **DateOfFirstProcedure**: Date of 1st procedure (YYYY-MM-DD)
- **ProcedureCount**: Number of completed procedures

### Backing Up Data

#### Manual Backup
1. Navigate to: `%LocalAppData%\EpilationProject\`
2. Copy `data.csv` to a backup location
3. Store safely (external drive, cloud storage, etc.)

#### Recommended Backup Strategy
- Weekly backups to external drive
- Monthly backups to cloud storage (OneDrive, Google Drive, Dropbox)
- Keep at least 3 versions

#### Restoring Data
1. Stop the application
2. Replace `data.csv` with backup file
3. Restart application

### Data Integrity

- Data is saved immediately after any change (add, update, delete)
- CSV format is simple and portable
- Can be opened/edited in Excel if needed (use caution!)
- Recommended: Use only through the app interface

---

## Architecture

### Technology Stack
- **Language**: C# (.NET Framework 4.8)
- **UI Framework**: Windows Forms
- **Data Storage**: CSV (file-based)
- **Email**: SMTP (Gmail)
- **Build Target**: .NET Framework 4.8

### Project Structure
```
EpilationProject/
├── EpilationProject.csproj          # Main project file
├── Form1.cs                         # Main UI form
├── Form1.Designer.cs                # Form designer (auto-generated)
├── Client.cs                        # Client data model
├── DataManager.cs                   # CSV file handling
├── NotificationChecker.cs           # Procedure notification logic
├── ProcedureScheduler.cs            # Procedure date calculation
├── EmailNotifier.cs                 # Email sending
├── SettingsForm.cs                  # Settings UI
├── SettingsForm.Designer.cs         # Settings form designer
├── SettingsManager.cs               # Settings file handling
├── Program.cs                       # Application entry point
└── Properties/                      # Project properties
	├── AssemblyInfo.cs
	├── Resources.resx
	└── Settings.settings
```

### Key Classes

#### Client
Represents a client with procedures.
```csharp
public class Client
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Phone { get; set; }
	public string Service { get; set; }
	public string Energy { get; set; }
	public string Phototype { get; set; }
	public DateTime DateOfFirstProcedure { get; set; }
	public int ProcedureCount { get; set; }
}
```

#### ProcedureScheduler
Calculates procedure schedules based on service and count.
```csharp
public class ProcedureScheduler
{
	public static DateTime CalculateNextProcedureDate(
		DateTime dateOfFirstProcedure, 
		int completedProcedureCount, 
		string service)

	public static bool IsNextProcedureUpcoming(
		Client client, 
		int daysAhead = 15)
}
```

#### NotificationChecker
Identifies upcoming procedures for notifications.
```csharp
public class NotificationChecker
{
	public List<Client> GetUpcomingProcedures(
		List<Client> clients, 
		int daysAhead = 15)

	public string GetUpcomingProceduresSummary(
		List<Client> clients, 
		int daysAhead = 15)
}
```

#### EmailNotifier
Sends SMTP emails.
```csharp
public class EmailNotifier
{
	public bool SendNotificationEmail(Client client)

	public void SendAllUpcomingReminders(List<Client> clients)
}
```

#### DataManager
Handles CSV file operations.
```csharp
public class DataManager
{
	public List<Client> LoadClients()

	public void SaveClients(List<Client> clients)

	public int GetNextId(List<Client> clients)
}
```

### Data Flow

```
User Input (Form)
		↓
Validation
		↓
Client Object Created/Modified
		↓
DataManager.SaveClients()
		↓
CSV File Updated
		↓
UI List Refreshed
```

### Notification Flow

```
User Clicks "Check Notifications"
		↓
Load All Clients
		↓
NotificationChecker.GetUpcomingProcedures()
		↓
ProcedureScheduler.IsNextProcedureUpcoming()
		↓
Filter clients with procedures in next 15 days
		↓
Show Summary Dialog
		↓
User Confirms → EmailNotifier sends emails
```

---

## Troubleshooting

### Common Issues

#### Application Won't Start
**Problem**: EpilationProject.exe won't launch

**Solutions**:
1. Verify .NET Framework 4.8 is installed
   - Open "Programs and Features" in Control Panel
   - Look for ".NET Framework 4.8"
   - If missing, download from: https://dotnet.microsoft.com/download/dotnet-framework/net48
2. Run as Administrator
   - Right-click EpilationProject.exe
   - Select "Run as Administrator"
3. Check Windows event log for errors
4. Reinstall the application

#### Data Not Saving
**Problem**: Changes are lost after closing the app

**Solutions**:
1. Check folder permissions
   - Verify `%LocalAppData%\EpilationProject\` exists and is writable
   - Right-click folder → Properties → Security → Edit
   - Ensure your user has "Full Control"
2. Disk space
   - Verify you have at least 100 MB free disk space
3. Run as Administrator
4. Try saving to a different location (contact developer)

#### Email Not Sending
**Problem**: "Error sending email" messages

**Solutions**:

| Error | Cause | Fix |
|-------|-------|-----|
| "Authentication failed" | Wrong password | Regenerate app password at myaccount.google.com/apppasswords |
| "requires secure connection" | Wrong SMTP settings | Verify: Server=smtp.gmail.com, Port=587 |
| "Timeout" | Network issue | Check internet connection, try again |
| "Email not configured" | Empty settings | Fill all settings fields and click Save |
| No emails in inbox | Spam folder | Check "Promotions" or "Spam" tabs in Gmail |

#### DateTimePicker Error
**Problem**: "System.ArgumentOutOfRangeException" when selecting a client

**Solutions**:
1. This error occurs if a client's date is before 1/1/1753
2. Update the client's "First Procedure Date"
   - Select the client
   - Set a valid date (1753 or later)
   - Click Update

#### Client Won't Add/Update
**Problem**: "Please fill in all fields" message

**Checklist**:
- ✅ Name: Entered and not empty
- ✅ Phone: Entered and not empty
- ✅ Service: One of the three options selected
- ✅ Procedure Count: Valid number (0 or higher)

#### Settings Won't Save
**Problem**: Settings revert after restart

**Solutions**:
1. Verify settings file location: `%LocalAppData%\EpilationProject\settings.txt`
2. Check file permissions (must be writable)
3. Restart application and try again
4. Run as Administrator

---

## FAQ

### General Questions

**Q: Is my data secure?**
A: Data is stored locally on your computer in CSV format. For security:
- Keep backup copies of your data
- Store the `%LocalAppData%\EpilationProject\` folder securely
- Consider using Windows file encryption (BitLocker)
- Never share the settings file (contains email passwords)

**Q: Can I use this on Mac or Linux?**
A: Currently, the application is Windows-only (.NET Framework 4.8). A future version could be ported to .NET 6+/.NET 8+ for cross-platform support.

**Q: How many clients can I manage?**
A: The app can handle thousands of clients. Performance depends on your computer:
- 100-500 clients: No issues
- 500-2000 clients: Smooth performance expected
- 2000+ clients: No technical limit, but loading may take a few seconds

**Q: Can I migrate data from another system?**
A: Yes! The CSV format is standard. You can:
1. Export your data into this format (CSV)
2. Replace `data.csv` with your file
3. Restart the application

**Q: What happens if I accidentally delete a client?**
A: Changes are saved immediately. To recover:
1. Restore `data.csv` from your backup
2. Restart the application

### Procedure Scheduling

**Q: Why do procedures have different intervals?**
A: Different body areas (face, body, legs) have different healing times and optimal treatment frequencies based on dermatological research.

**Q: Can I customize the intervals?**
A: Currently, intervals are fixed per service. To customize, you would need to modify the source code. Contact the developer for custom intervals.

**Q: What if a client skips a procedure?**
A: You can still manage this:
1. Don't update their procedure count
2. The app continues calculating from where they left off
3. Update their "First Procedure Date" if needed for recalculation

**Q: How accurate is the scheduling?**
A: The app calculates based on:
- Fixed intervals per service type
- The date of the first procedure
- The procedure count
- Results are consistent and predictable

### Email & Notifications

**Q: Why do I need Gmail?**
A: The app uses Gmail SMTP for reliability. You can:
- Use your clinic Gmail account
- Create a dedicated Gmail account for notifications
- Use Gmail even if you prefer checking email elsewhere

**Q: Will clients receive emails directly?**
A: No. Emails are sent to **you** (the configured email address). You then contact clients as needed. This allows you to:
- Review upcoming procedures
- Prepare for appointments
- Add notes before contacting clients

**Q: Can I send emails to clients automatically?**
A: Not currently. The app reminds **you** via email. A future version could support direct client notifications.

**Q: What if I don't want email notifications?**
A: You can:
- Leave email settings blank (no notifications will send)
- Manually check "Check Notifications" button anytime
- View the summary without sending emails

**Q: Can I customize the email template?**
A: Currently, the email format is fixed. To customize, you would need to modify the source code or contact the developer.

### Technical Questions

**Q: What is .NET Framework 4.8?**
A: It's Microsoft's runtime for running Windows applications. Most Windows PCs have it pre-installed. If not, download from:
https://dotnet.microsoft.com/download/dotnet-framework/net48

**Q: Is the source code available?**
A: Yes! The project is open-source:
https://github.com/Johnny-be-coding/EpilationProject

**Q: Can I modify the app for my needs?**
A: Yes, the source code is available. You can:
1. Fork the repository
2. Modify the code
3. Compile and run locally
4. Submit pull requests for improvements

**Q: Where is the data stored exactly?**
A: `C:\Users\[YourUsername]\AppData\Local\EpilationProject\`

Substitute `[YourUsername]` with your Windows username.

**Q: Can I move the data to a different location?**
A: Currently, the app uses a fixed location. To use a different location, you would need to modify the source code in `DataManager.cs` and `SettingsManager.cs`.

---

## Support & Feedback

### Getting Help
1. **Check this documentation** first - most issues are covered here
2. **Review the Troubleshooting section** - common solutions
3. **Check GitHub Issues**: https://github.com/Johnny-be-coding/EpilationProject/issues

### Reporting Bugs
1. Go to: https://github.com/Johnny-be-coding/EpilationProject/issues
2. Click "New Issue"
3. Provide:
   - What you were doing
   - What error/behavior occurred
   - Your Windows version and .NET Framework version
   - Steps to reproduce

### Feature Requests
1. GitHub Issues: https://github.com/Johnny-be-coding/EpilationProject/issues
2. Label as "enhancement" or "feature request"
3. Describe the desired functionality

### Contributing
See GitHub repository for contribution guidelines.

---

## Version History

### Version 1.0 (Latest)
- Initial release
- Core client management
- Procedure scheduling with service-specific intervals
- Email notifications via Gmail
- CSV-based data storage
- Settings management

### Planned Features (Future)
- Direct client email notifications
- SMS reminders
- Customizable service types and intervals
- Multi-user support
- Database backend option (SQL Server, SQLite)
- Mobile app companion
- Calendar view
- Analytics and reporting
- Backup automation
- Google Calendar integration

---

## Legal & Security Notes

### Data Privacy
- Your client data is stored **locally** on your computer
- No data is sent to external servers (except emails via Gmail)
- You are responsible for data security and privacy
- Follow GDPR, HIPAA, or local regulations as applicable

### Terms of Use
- Use at your own risk
- The application is provided "as-is"
- No warranty or liability for data loss
- Always maintain backups

### Licensing
See LICENSE file in GitHub repository.

---

## Contact & Information

**Project**: EpilationProject - Client Manager
**Repository**: https://github.com/Johnny-be-coding/EpilationProject
**License**: [See repository for details]

---

**Last Updated**: 2025
**Documentation Version**: 1.0

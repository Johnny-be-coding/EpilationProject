# Email Feature Testing Guide

## Overview
The EpilationProject uses Gmail's SMTP server to send appointment reminder emails. Follow these steps to test the email feature.

## Step 1: Get Gmail Credentials

### Option A: Using Your Personal Gmail Account (Recommended for Testing)

1. Go to [Google Account Settings](https://myaccount.google.com)
2. Navigate to **Security** (left sidebar)
3. Scroll down to **App passwords** (only available if 2-Factor Authentication is enabled)
   - If you don't have 2FA enabled, enable it first:
	 - Click "2-Step Verification"
	 - Follow the steps to enable it
4. Once 2FA is enabled, go back to Security → App passwords
5. Select **Mail** and **Windows Computer** (or your device)
6. Google will generate a 16-character app password
7. Copy this password - **you'll need it**

### Option B: Using a Test Email Account

Create a new Gmail account specifically for testing:
1. Go to [Google Account Creation](https://accounts.google.com/signup)
2. Create a test account (e.g., `epilationproject.test@gmail.com`)
3. Enable 2-Factor Authentication
4. Generate an App Password (steps 4-6 above)

## Step 2: Configure Settings in the Application

### First Time Setup:

1. Run **EpilationProject.exe**
2. Click the **⚙️ Settings** button
3. Fill in the following fields:

   | Field | Value |
   |-------|-------|
   | **Epilation Person Name** | Your Name (or "Test Person") |
   | **Epilation Person Email** | The email where you want to receive reminders (e.g., your personal email) |
   | **SMTP Server** | `smtp.gmail.com` |
   | **SMTP Port** | `587` |
   | **SMTP Username** | Your Gmail address (e.g., `your.email@gmail.com`) |
   | **SMTP Password** | The 16-character app password generated in Step 1 |

4. Click **Save Settings**

### Example Configuration:
```
Epilation Person Name: John Doe
Epilation Person Email: my.personal.email@gmail.com
SMTP Server: smtp.gmail.com
SMTP Port: 587
SMTP Username: epilationproject.test@gmail.com
SMTP Password: abcd efgh ijkl mnop
```

## Step 3: Add Test Clients with Upcoming Procedures

1. Add a new client with the following:
   - **Name**: Test Client 1
   - **Phone**: 123-456-7890
   - **Service**: Procedure FACE
   - **Energy**: 20
   - **Phototype**: IV
   - **Date of First Procedure**: Set to a date **within the next 15 days**
	 - Example: If today is January 15, set it to January 20-29

2. Add another client with an upcoming date:
   - **Name**: Test Client 2
   - **Date of First Procedure**: Tomorrow or within 15 days

3. Add a client with a date **outside 15 days** (should NOT receive notification):
   - **Name**: Test Client 3
   - **Date of First Procedure**: 30 days from now

## Step 4: Test the Email Feature

### Testing Notifications:

1. Click **Check Notifications** button
2. You should see a dialog showing:
   ```
   Upcoming procedures in the next 15 days:

   • Test Client 1 - January 20, 2025 (Procedure FACE)
   • Test Client 2 - January 16, 2025 (Procedure FACE)
   ```

3. Click **Yes** to send emails
4. You should see: `Successfully sent 2 notification email(s).`

### Checking Received Emails:

1. Go to the email account you configured as "Epilation Person Email"
2. Check the **Inbox** (or Spam/Promotions folder)
3. Look for emails with subject: `Epilation Appointment Reminder - [Client Name]`
4. The email should contain:
   - Client name, phone, service
   - Scheduled procedure date
   - Energy and phototype settings
   - Formatted as an HTML table

## Step 5: Troubleshooting

### Common Issues:

| Issue | Solution |
|-------|----------|
| **"Email settings not configured"** | Click Settings and ensure all SMTP fields are filled in |
| **"Error sending email: The SMTP server requires a secure connection"** | Ensure SMTP Port is `587` and SSL is enabled (it is by default) |
| **No emails received** | Check Spam/Promotions folder; Gmail may filter automated emails |
| **"Authentication failed"** | Verify your Gmail and App Password are correct; try copying & pasting again |
| **"Timeout"** | Check your internet connection; Gmail may take 5-10 seconds |
| **"No upcoming procedures"** | Ensure client dates are within the next 15 days from today |

### Test with Invalid Credentials:

To verify error handling works:
1. In Settings, intentionally use wrong credentials
2. Click Check Notifications
3. You should see an error message (not a crash)

## Testing Checklist

- [ ] Settings save successfully
- [ ] Upcoming procedures are detected (clients within 15 days shown)
- [ ] Non-upcoming procedures are ignored (clients outside 15 days)
- [ ] Email sends without errors
- [ ] Email is received in the correct inbox or spam folder
- [ ] Email contains all required information (client details, date, service)
- [ ] Error handling works (no crashes on invalid credentials)
- [ ] Cancel button works (doesn't send emails)

## Security Notes

⚠️ **IMPORTANT:**
- Never use your primary Gmail account password - **always use App Passwords**
- The app stores settings in: `%LocalAppData%\EpilationProject\settings.txt`
- Credentials are stored in **plain text** - this is a test application
- Consider deleting test credentials after testing
- Do not commit real credentials to version control

## Cleanup

To reset for next test:
1. Delete the settings file in `%LocalAppData%\EpilationProject\settings.txt`
2. Or use Settings button to clear all fields and enter new credentials

---

**Questions?** Check the email logs or error messages shown in dialogs.

# Google 2-Factor Authentication Setup - Detailed Guide

## What is 2FA?
2-Factor Authentication (2FA) adds an extra security layer to your Gmail account. You'll need:
1. Your password
2. A verification code from your phone or email

This is **required** to generate App Passwords that the EpilationProject can use.

---

## Step-by-Step 2FA Setup

### Step 1: Go to Google Account Settings
1. Open your web browser
2. Go to: https://myaccount.google.com
3. Log in with your test Gmail account (e.g., `epilationproject.test@gmail.com`)
4. You'll see your Google Account dashboard

### Step 2: Navigate to Security Settings
1. On the left sidebar, look for **Security** (it's near the top)
2. Click on **Security**
3. You should see various security options on the right side

### Step 3: Enable 2-Step Verification
1. Scroll down on the Security page until you find **2-Step Verification**
   - It will say something like "Add a backup verification method" or "2-Step Verification is off"
2. Click on **2-Step Verification**

### Step 4: Start the Setup Process
1. A page will open saying "Get an extra layer of security"
2. Click the **Get Started** button
3. You may be asked to re-enter your password - do so

### Step 5: Choose Your Verification Method
You'll see options for how to receive verification codes. Choose ONE:

#### Option A: Authenticator App (Recommended)
1. Select **Authenticator app**
2. Click **Can't use your phone?** if you want email instead
3. Download an app:
   - **Google Authenticator** (iOS/Android)
   - **Microsoft Authenticator** (iOS/Android)
   - **Authy** (iOS/Android)
4. Open the app on your phone
5. Scan the QR code shown on the screen with your authenticator app
6. The app will show a 6-digit code
7. Enter that 6-digit code into the Google page
8. Click **Verify**

#### Option B: Text Message (SMS)
1. Select **Text message**
2. Enter your phone number
3. Google will send you a text with a 6-digit code
4. Enter that code on the screen
5. Click **Verify**

#### Option C: Email (Simplest for Testing)
1. Select **Email**
2. Google will send a code to your Gmail
3. Check your email inbox (in the same account)
4. Copy the 6-digit code
5. Enter it on the screen
6. Click **Verify**

### Step 6: Save Backup Codes
1. After verifying, Google will show you **backup codes** (8-digit codes)
2. You'll get 10 of these codes
3. **IMPORTANT**: Write these down or save them somewhere safe
4. These are backup codes if you lose access to your phone/email
5. Click **Done** or **I've saved my backup codes**

### Step 7: Verify 2FA is Enabled
1. You should see a screen saying "2-Step Verification is on"
2. Go back to the Security page (https://myaccount.google.com/security)
3. You should now see "2-Step Verification is on" under that section

---

## Troubleshooting 2FA Setup

| Problem | Solution |
|---------|----------|
| **"Can't receive text messages"** | Use Authenticator App instead - it doesn't need texts |
| **"Authenticator app won't scan QR code"** | Try the "Can't scan it?" option to manually enter a code |
| **"Backup codes not showing"** | Don't worry - you can view/generate them later in Security settings |
| **"Google keeps asking for verification"** | This is normal - 2FA is working! Just complete each verification |
| **"Device not being recognized"** | Check "Trust this device for 30 days" to reduce future prompts |

---

## Next Steps After 2FA is Enabled

Once 2FA is ON:

1. Go directly to: https://myaccount.google.com/apppasswords
2. You should see an **"App name"** text field
3. Type a name like `EpilationProject`, `Mail`, or `Windows`
4. Click the **Create** button
5. Google will display a 16-character password (usually shown in a highlighted box)
6. **Copy this password** - this is what you use in EpilationProject Settings

---

## Quick Reference: 2FA Setup Summary

```
1. Go to: https://myaccount.google.com
2. Click: Security (left sidebar)
3. Find: 2-Step Verification
4. Click: Start setup
5. Choose: Authenticator app, SMS, or Email
6. Verify: Enter the 6-digit code
7. Save: Backup codes (write them down!)
8. Done: 2-Step Verification is on
```

---

## Having Issues?

### 2FA Still Not Showing?
- Wait a few minutes - sometimes it takes time to propagate
- Try logging out and back in
- Use a different browser (Chrome, Firefox, etc.)

### Can't Find "App Passwords"?
- Make sure 2FA is actually enabled (check Security page again)
- Try this direct link: https://myaccount.google.com/apppasswords
- If it says "No app passwords available yet" - create one by selecting Mail + Windows Computer

### Still Stuck?
Create a simpler Gmail account test:
1. Use a Gmail account that already has 2FA enabled
2. Or use a different email provider (Outlook, Yahoo)

---

## Security Reminders

✅ **Do:**
- Keep your 16-character app password safe
- Save your 10 backup codes in case you lose access
- Close your browser when done

❌ **Don't:**
- Share your app password with anyone
- Commit passwords to Git or version control
- Use the same test password everywhere

---

**Once 2FA is enabled, come back to the main EMAIL_TESTING_GUIDE.md and continue from Step 1 Step 2 (Get Gmail Credentials - Option A)**

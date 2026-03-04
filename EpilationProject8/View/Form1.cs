using EpilationProject8.Model;
using System;
using System.Windows.Forms;
using System.Data.Entity;
using System.Linq;


namespace EpilationProject8
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ensure database schema matches the EDMX (Id should be IDENTITY).
            // This will attempt a safe, one-time fix at startup if the column is not identity.
            EnsureIdentityOnIdColumn();

            LoadData();
            RemoveZeroIdRowsIfAny();

        }
        // One-time cleanup method: deletes any rows whose Id == 0.
        // Use only until you fix the EDMX/DB to use identity keys.
        private void RemoveZeroIdRowsIfAny()
        {
            try
            {
                using (var db = new EpilationEntities())
                {
                    var badRows = db.Epilations.Where(x => x.Id == 0).ToList();
                    if (badRows.Count == 0) return;

                    db.Epilations.RemoveRange(badRows);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Keep UI responsive and surface a concise message.
                // In production, log the full exception instead.
                MessageBox.Show("Cleanup failed: " + ex.Message, "Cleanup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Ensure the physical database column 'Id' is an IDENTITY. If not, create a new table
        // with an IDENTITY, copy data, drop old table and rename the new one. Runs once at startup.
        private void EnsureIdentityOnIdColumn()
        {
            try
            {
                using (var db = new EpilationEntities())
                {
                    // Check if column is identity (1) or not (0/null)
                    var isIdentity = db.Database.SqlQuery<int?>(
                        "SELECT COLUMNPROPERTY(OBJECT_ID('dbo.Epilation'), 'Id', 'IsIdentity')").FirstOrDefault();

                    if (isIdentity.GetValueOrDefault(0) == 1)
                    {
                        return; // already identity
                    }

                    // Build SQL to create a new table with IDENTITY, copy data, replace old table.
                    // This is a one-time structural fix; it assumes there are no foreign keys referencing Epilation.
                    var sql = @"
BEGIN TRY
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    IF OBJECT_ID('dbo.Epilation_New', 'U') IS NOT NULL
        DROP TABLE dbo.Epilation_New;

    CREATE TABLE dbo.Epilation_New (
      Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
      DateLastEpilationTorseHands TEXT NULL,
      DateLastEpilationHead TEXT NULL,
      DateLastEpilationTorseFeet TEXT NULL,
      DateLastEpilationIntim TEXT NULL
    );

    SET IDENTITY_INSERT dbo.Epilation_New ON;

    INSERT INTO dbo.Epilation_New (Id, DateLastEpilationTorseHands, DateLastEpilationHead, DateLastEpilationTorseFeet, DateLastEpilationIntim)
    SELECT Id, DateLastEpilationTorseHands, DateLastEpilationHead, DateLastEpilationTorseFeet, DateLastEpilationIntim FROM dbo.Epilation;

    SET IDENTITY_INSERT dbo.Epilation_New OFF;

    DROP TABLE dbo.Epilation;
    EXEC sp_rename 'dbo.Epilation_New', 'Epilation';

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    DECLARE @Msg NVARCHAR(4000) = ERROR_MESSAGE();
    RAISERROR(@Msg, 16, 1);
END CATCH
";

                    db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
                }
            }
            catch (Exception ex)
            {
                // Surface a clear message and abort further DB operations. In production, log details.
                MessageBox.Show("Database schema fix failed: " + ex.Message + "\nPlease ensure the Epilation.Id column is an IDENTITY and that no foreign keys reference the table.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            using (var db = new EpilationEntities())
            {
                // Load list and bind to DataGridView
                var list = db.Epilations.AsNoTracking().ToList();
                dgvEpilations.DataSource = list;
            }

            ClearEditor();
        }

        private void ClearEditor()
        {
            txtId.Text = string.Empty;
            txtDateLastEpilationHead.Text = string.Empty;
            txtDateLastEpilationIntim.Text = string.Empty;
            txtDateLastEpilationTorseFeet.Text = string.Empty;
            txtDateLastEpilationTorseHands.Text = string.Empty;
        }

        private void dgvEpilations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEpilations.CurrentRow == null) return;

            var item = dgvEpilations.CurrentRow.DataBoundItem as Epilation;
            if (item == null) return;

            txtId.Text = item.Id.ToString();

            txtDateLastEpilationHead.Text = item.DateLastEpilationHead;
            txtDateLastEpilationIntim.Text = item.DateLastEpilationIntim;
            txtDateLastEpilationTorseFeet.Text = item.DateLastEpilationTorseFeet;
            txtDateLastEpilationTorseHands.Text = item.DateLastEpilationTorseHands;
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (var db = new EpilationEntities())
            {
                var entity = new Epilation
                {
                    DateLastEpilationHead = txtDateLastEpilationHead.Text,
                    DateLastEpilationIntim = txtDateLastEpilationIntim.Text,
                    DateLastEpilationTorseFeet = txtDateLastEpilationTorseFeet.Text,
                    DateLastEpilationTorseHands = txtDateLastEpilationTorseHands.Text
                };

                db.Epilations.Add(entity);
                db.SaveChanges();
            }

            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Select a row to update (Id must be present).", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new EpilationEntities())
            {
                var entity = db.Epilations.Find(id);
                if (entity == null)
                {
                    MessageBox.Show("Record not found.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                entity.DateLastEpilationHead = txtDateLastEpilationHead.Text;
                entity.DateLastEpilationIntim = txtDateLastEpilationIntim.Text;
                entity.DateLastEpilationTorseFeet = txtDateLastEpilationTorseFeet.Text;
                entity.DateLastEpilationTorseHands = txtDateLastEpilationTorseHands.Text;

                db.SaveChanges();
            }

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Select a row to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Delete selected record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var db = new EpilationEntities())
            {
                var entity = db.Epilations.Find(id);
                if (entity == null)
                {
                    MessageBox.Show("Record not found.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db.Epilations.Remove(entity);
                db.SaveChanges();
            }

            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void groupBoxEditor_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
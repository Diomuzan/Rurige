using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;
using Oqtane.Migrations.Framework;
using Oqtane.Models;

// ReSharper disable ClassNeverInstantiated.Global

namespace Oqtane.Database.PostgreSQL
{
    public class OqtaneHistoryRepository : NpgsqlHistoryRepository
    {
        private string _appliedDateColumnName = "applied_date";
        private string _appliedVersionColumnName = "applied_version";
        private MigrationHistoryTable _migrationHistoryTable;

        public OqtaneHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
        {
            _migrationHistoryTable = new MigrationHistoryTable
            {
                TableName = TableName,
                TableSchema = TableSchema,
                MigrationIdColumnName = MigrationIdColumnName,
                ProductVersionColumnName = ProductVersionColumnName,
                AppliedVersionColumnName = _appliedVersionColumnName,
                AppliedDateColumnName = _appliedDateColumnName
            };

        }

        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);
            history.Property<string>(_appliedVersionColumnName).HasMaxLength(10);
            history.Property<DateTime>(_appliedDateColumnName);
        }

        public override string GetInsertScript(HistoryRow row)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }

            return MigrationUtils.BuildInsertScript(row, Dependencies, _migrationHistoryTable);
        }
    }
}

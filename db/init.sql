CREATE DATABASE aposp_report_db;
CREATE USER aposp_report_user WITH PASSWORD 'aposp_report_password';
GRANT ALL PRIVILEGES ON DATABASE "aposp_report_db" to aposp_report_user;
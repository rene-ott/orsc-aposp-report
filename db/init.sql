CREATE DATABASE aposp_report_db;
CREATE USER aposp_report_app WITH PASSWORD 'aposp_report_app_password';
GRANT ALL PRIVILEGES ON DATABASE "aposp_report_db" to aposp_report_app;
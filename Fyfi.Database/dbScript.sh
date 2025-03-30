#!/bin/bash 

sqlpackage /Action:Extract /SourceConnectionString:"data source=DESKTOP-O06HF0H;initial catalog=FyfiDatabase;trusted_connection=true;TrustServerCertificate=True" /TargetFile:"MyDatabaseProject.dacpac"


read -p "Press any key to continue" x
import { Component, Inject, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { BankReportItemDialogData } from './bank-report-item-dialog-data.model';

@Component({
  selector: 'app-bank-report-item-dialog',
  templateUrl: './bank-report-item-dialog.component.html',
  styleUrls: ['./bank-report-item-dialog.component.scss']
})
export class BankReportItemDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: BankReportItemDialogData) {}
}

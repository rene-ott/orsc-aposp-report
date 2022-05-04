import { Component, Inject, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ItemReportItemDialogData } from './item-report-item-dialog-data.model';

@Component({
  selector: 'app-bank-report-item-dialog',
  templateUrl: './item-report-item-dialog.component.html',
  styleUrls: ['./item-report-item-dialog.component.scss']
})
export class ItemReportItemDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: ItemReportItemDialogData) {}
}

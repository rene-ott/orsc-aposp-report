import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ImageDialogComponent } from '../image-dialog/image-dialog.component';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})
export class ImageComponent implements OnInit {

  @Input()
  base64EncodedString: string = "";

  constructor(public dialog: MatDialog) { }

  openBankReportItemDialog() {
    this.dialog.open(ImageDialogComponent, {
      data: {
        base64EncodedString: this.base64EncodedString
    }});
  }

  ngOnInit() {
  }
}

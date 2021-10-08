import { Component, Input, OnInit } from '@angular/core';
import { ReportItem } from './report-item.model';

@Component({
  selector: 'app-report-item',
  templateUrl: './report-item.component.html',
  styleUrls: ['./report-item.component.scss']
})
export class ReportItemComponent implements OnInit {

  hasContent: boolean = false;
  itemCount: string = "";
  imageSrc: string = "";

  @Input()
  item: ReportItem | null = null;

  ngOnInit(): void {
    this.hasContent = !!this.item;

    if (this.item == null) {
      return;
    }

    this.imageSrc = `/images/items/${this.item.id}.png`;
    this.itemCount = this.item.isStackable
     ? `[${this.item.count}]`
     : this.item.count.toString();
  }
}

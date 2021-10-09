import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ReportItem } from './report-item.model';

@Component({
  selector: 'app-report-item',
  templateUrl: './report-item.component.html',
  styleUrls: ['./report-item.component.scss']
})
export class ReportItemComponent implements OnInit {

  isSelected = false;
  hasContent: boolean = false;
  itemCount: string = "";
  imageSrc: string = "";

  @Input()
  item: ReportItem | null = null;

  @Output()
  reportItemSelect: EventEmitter<ReportItem> = new EventEmitter();

  @Input()
  selectable: boolean = false;

  selectItem() {
    if (!this.selectable || this.item == null) {
      return;
    }

    this.isSelected = true;
    this.reportItemSelect.emit(this.item);
  }

  deselectItem() {
    this.isSelected = false;
  }

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

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ReportItemSelectionChangedEvent } from './report-item-selection-changed-event.model';
import { ReportItem } from './report-item.model';

@Component({
  selector: 'app-report-item',
  templateUrl: './report-item.component.html',
  styleUrls: ['./report-item.component.scss']
})
export class ReportItemComponent<T extends ReportItem> implements OnInit {

  isSelected = false;
  hasContent: boolean = false;
  imageSrc: string = "";

  @Input()
  text: string = "";

  @Input()
  item: T | null = null;

  @Output()
  reportItemSelect: EventEmitter<ReportItemSelectionChangedEvent> = new EventEmitter();

  @Input()
  selectable: boolean = false;

  @Input()
  isOpaque: boolean = false;

  selectItem() {
    if (!this.selectable || this.item == null) {
      return;
    }

    this.isSelected = !this.isSelected;
    this.reportItemSelect.emit(new ReportItemSelectionChangedEvent(this.item, this.isSelected));
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
  }
}

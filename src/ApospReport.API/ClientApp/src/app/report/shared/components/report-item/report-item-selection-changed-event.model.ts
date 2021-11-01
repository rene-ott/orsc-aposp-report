import { ReportItem } from "./report-item.model";

export class ReportItemSelectionChangedEvent {
    item: ReportItem;
    isSelected: boolean
   
    constructor(item: ReportItem, isSelected: boolean) {
      this.item = item;
      this.isSelected = isSelected;
    }
  }
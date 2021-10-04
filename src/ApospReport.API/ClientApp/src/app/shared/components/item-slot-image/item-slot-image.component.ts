import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-item-slot-image',
  templateUrl: './item-slot-image.component.html',
  styleUrls: ['./item-slot-image.component.scss']
})
export class ItemSlotImageComponent implements OnInit {

  @Input()
  base64!: string;

  @Input()
  count!: number;

  data!: string;
  isVisible: boolean = false

  constructor() { }

  ngOnInit(): void {
    this.data = `data:image/png;base64,${this.base64}`;
    this.isVisible = !!this.base64
  }
}

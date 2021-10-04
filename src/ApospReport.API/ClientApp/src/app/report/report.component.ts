import { Component, OnInit } from '@angular/core';
import { Router, RouterLinkActive } from '@angular/router';
import { ItemImageService } from '../shared/services/item-image.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: []
})
export class ReportComponent implements OnInit {
  navLinks: any[];
  activeLinkIndex = -1;

  constructor(private router: Router, private itemImageService: ItemImageService) {
    this.navLinks = [
      { label: 'Account reports', link: './account', index: 0 },
      { label: 'Total bank report', link: './bank', index: 1 },
    ];
  }
  ngOnInit(): void {
    this.router.events.subscribe(() => {
      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });

    this.itemImageService.downloadItemImages().subscribe(x => {
      console.log(x);
    })
  }
}

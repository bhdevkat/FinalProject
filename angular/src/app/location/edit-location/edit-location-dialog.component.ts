import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  LocationServiceProxy,
  LocationDto
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-location',
  templateUrl: './edit-location-dialog.component.html'
})

export class EditLocationDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  location: LocationDto = new LocationDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _locationService: LocationServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._locationService.get(this.id).subscribe((result: LocationDto) => {
      this.location = result;
    });
  }

  save(): void {
    this.saving = true;

    this._locationService.update(this.location).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}

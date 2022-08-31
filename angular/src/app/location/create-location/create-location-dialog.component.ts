import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  LocationServiceProxy,
  CreateLocationDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  selector: 'app-create-location',
  templateUrl: './create-location-dialog.component.html'
})

export class CreateLocationDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  location = new CreateLocationDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _locationService: LocationServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }
 
  save(): void {
    this.saving = true;
    this._locationService
      .create(this.location)
      .subscribe(
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

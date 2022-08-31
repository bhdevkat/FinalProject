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
  TripServiceProxy,
  TripDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  selector: 'app-create-trip',
  templateUrl: './create-trip-dialog.component.html'
})

export class CreateTripDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  trip = new TripDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _tripService: TripServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }
 
  save(): void {
    this.saving = true;
    this._tripService
      .create(this.trip)
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

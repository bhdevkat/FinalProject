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
  TripServiceProxy,
  TripDto
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-trip',
  templateUrl: './edit-trip-dialog.component.html'
})

export class EditTripDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  trip: TripDto = new TripDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _tripService: TripServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._tripService.get(this.id).subscribe((result: TripDto) => {
      this.trip = result;
    });
  }

  save(): void {
    this.saving = true;

    this._tripService.update(this.trip).subscribe(
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

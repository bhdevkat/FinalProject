import { Component, Injector, ChangeDetectionStrategy } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { HomeDto, HomeServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {
  statistics: HomeDto;

  constructor(injector: Injector,public _homeService: HomeServiceProxy,) {
    super(injector);
  }

  ngOnInit(): void {
    this.list();
}

protected list(
    // finishedCallback: Function

): void {
    this._homeService
        .getStatisticalData()
        .pipe(
            finalize(() => {
                // finishedCallback();
            })
        )
        .subscribe((result) => {
            this.statistics = result;
        });
}


}

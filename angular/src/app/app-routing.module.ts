import { BoardingComponent } from './boarding/boarding.component';
import { BusComponent } from './bus/bus.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { StudentComponent } from './student/student.component';
import { StaffComponent } from './staff/staff.component';
import { TripComponent } from './trip/trip.component';
import { LocationComponent } from './location/location.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { ScheduleDetailsComponent } from './schedule/details-schedule/schedule-details/schedule-details.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] },
                    { path: 'student', component: StudentComponent},
                    { path: 'bus', component: BusComponent },
                    { path: 'boarding', component: BoardingComponent },
                    { path: 'staff', component: StaffComponent },
                    { path: 'trip', component: TripComponent },
                    { path: 'location', component: LocationComponent },
                    { path: 'schedule', component: ScheduleComponent },
                    { path: 'scheduleDetails/:id', component: ScheduleDetailsComponent },
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
